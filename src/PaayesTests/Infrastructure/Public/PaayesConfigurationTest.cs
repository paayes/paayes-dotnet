namespace PaayesTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Paayes;
    using Xunit;

    public class PaayesConfigurationTest : BasePaayesTest
    {
        [Fact]
        public void PaayesClient_Getter_CreatesNewPaayesClientIfNullAndApiKeyIsSet()
        {
            var origApiKey = PaayesConfiguration.ApiKey;
            var origClientId = PaayesConfiguration.ClientId;

            try
            {
                PaayesConfiguration.ApiKey = "sk_key_paayesconfiguration";
                PaayesConfiguration.ClientId = "ca_paayesconfiguration";
                PaayesConfiguration.PaayesClient = null;

                var client = PaayesConfiguration.PaayesClient;
                Assert.NotNull(client);
                Assert.Equal(PaayesConfiguration.ApiKey, client.ApiKey);
                Assert.Equal(PaayesConfiguration.ClientId, client.ClientId);
            }
            finally
            {
                PaayesConfiguration.ApiKey = origApiKey;
                PaayesConfiguration.ClientId = origClientId;
            }
        }

        [Fact]
        public void PaayesClient_Getter_CreatesNewPaayesClientIfNullAndApiKeyIsNull()
        {
            var origApiKey = PaayesConfiguration.ApiKey;

            try
            {
                PaayesConfiguration.ApiKey = null;
                PaayesConfiguration.PaayesClient = null;

                var client = PaayesConfiguration.PaayesClient;
                Assert.NotNull(client);
                Assert.Null(client.ApiKey);
            }
            finally
            {
                PaayesConfiguration.ApiKey = origApiKey;
            }
        }

        [Fact]
        public void PaayesClient_Getter_ThrowsIfClientIsNullAndApiKeyIsEmpty()
        {
            var origApiKey = PaayesConfiguration.ApiKey;

            try
            {
                PaayesConfiguration.ApiKey = string.Empty;
                PaayesConfiguration.PaayesClient = null;

                var exception = Assert.Throws<PaayesException>(() =>
                    PaayesConfiguration.PaayesClient);
                Assert.Contains("Your API key is invalid, as it is an empty string.", exception.Message);
            }
            finally
            {
                PaayesConfiguration.ApiKey = origApiKey;
            }
        }

        [Fact]
        public void PaayesClient_Getter_ThrowsIfClientIsNullAndApiKeyContainsWhitespace()
        {
            var origApiKey = PaayesConfiguration.ApiKey;

            try
            {
                PaayesConfiguration.ApiKey = "sk_paayesconfiguration\n";
                PaayesConfiguration.PaayesClient = null;

                var exception = Assert.Throws<PaayesException>(() =>
                    PaayesConfiguration.PaayesClient);
                Assert.Contains("Your API key is invalid, as it contains whitespace.", exception.Message);
            }
            finally
            {
                PaayesConfiguration.ApiKey = origApiKey;
            }
        }
    }
}
