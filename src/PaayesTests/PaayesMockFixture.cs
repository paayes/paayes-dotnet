namespace PaayesTests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Paayes;

    public class PaayesMockFixture : IDisposable
    {
        /// <value>Minimum required version of paayes-mock.</value>
        /// <remarks>
        /// If you bump this, don't forget to bump <c>PAAYES_MOCK_VERSION</c> in <c>appveyor.yml</c>
        /// as well.
        /// </remarks>
        private const string MockMinimumVersion = "0.109.0";

        private readonly string port;

        public PaayesMockFixture()
        {
            if (PaayesMockHandler.StartPaayesMock())
            {
                this.port = PaayesMockHandler.Port.ToString();
            }
            else
            {
                this.port = Environment.GetEnvironmentVariable("PAAYES_MOCK_PORT") ?? "12111";
            }

            this.EnsurePaayesMockMinimumVersion();
        }

        public void Dispose()
        {
            PaayesMockHandler.StopPaayesMock();
        }

        /// <summary>
        /// Creates and returns a new instance of <see cref="PaayesClient"/> suitable for use with
        /// paayes-mock.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <returns>The new <see cref="PaayesClient"/> instance.</returns>
        public PaayesClient BuildPaayesClient(IHttpClient httpClient = null)
        {
            return new PaayesClient(
                "sk_test_123",
                "ca_123",
                httpClient: httpClient,
                apiBase: $"http://localhost:{this.port}",
                filesBase: $"http://localhost:{this.port}");
        }

        /// <summary>
        /// Gets fixture data with expansions specified. Expansions are specified the same way as
        /// they are in the normal API like <c>customer</c> or <c>data.customer</c>.
        /// Use the special <c>*</c> character to specify that all fields should be
        /// expanded.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for paayes-mock.</param>
        /// <param name="expansions">Set of expansions that should be applied.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        public string GetFixture(string path, string[] expansions = null)
        {
            string url = $"http://localhost:{this.port}{path}";

            if (expansions != null)
            {
                string query = string.Join("&", expansions.Select(x => $"expand[]={x}").ToArray());
                url += $"?{query}";
            }

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        "sk_test_123");

                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new PaayesTestException(
                        $"Couldn't reach paayes-mock at `localhost:{this.port}`. "
                        + "Is it running? Please see README for setup instructions.");
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new PaayesTestException(
                        $"paayes-mock returned status code: {response.StatusCode}.");
                }

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Compares two version strings.
        /// </summary>
        /// <param name="a">A version string (e.g. "1.2.3").</param>
        /// <param name="b">Another version string.</param>
        /// <returns>-1 if a &gt; b, 1 if a &lt; b, 0 if a == b.</returns>
        private static int CompareVersions(string a, string b)
        {
            var version1 = new Version(a);
            var version2 = new Version(b);
            return version2.CompareTo(version1);
        }

        private void EnsurePaayesMockMinimumVersion()
        {
            string url = $"http://localhost:{this.port}";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new PaayesTestException(
                        $"Couldn't reach paayes-mock at `localhost:{this.port}`. "
                        + "Is it running? Please see README for setup instructions.");
                }

                string version = response.Headers.GetValues("Paayes-Mock-Version").FirstOrDefault();

                if (!version.Equals("master") &&
                    (CompareVersions(version, MockMinimumVersion) > 0))
                {
                    throw new PaayesTestException(
                        $"Your version of paayes-mock ({version}) is too old. The minimum "
                        + $"version to run this test suite is {MockMinimumVersion}. Please see its "
                        + "repository for upgrade instructions.");
                }
            }
        }
    }
}
