namespace PaayesTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public static class PaayesMockHandler
    {
        private static Process process;

        private static int port = -1;

        /// <summary>
        /// Gets the port on which paayes-mock is listening, or -1 if no paayes-mock process was
        /// started.
        /// </summary>
        public static int Port { get => port; }

        /// <summary>
        /// Starts a paayes-mock process on an available port, if necessary.
        /// </summary>
        /// <returns>True if a paayes-mock process was started, false otherwise.</returns>
        public static bool StartPaayesMock()
        {
            var specPath = Path.GetFullPath("openapi/spec3.json");
            var fixturesPath = Path.GetFullPath("openapi/fixtures3.json");

            if (!File.Exists(specPath))
            {
                return false;
            }

            if ((process != null) && !process.HasExited)
            {
                Console.WriteLine($"paayes-mock is already running on port #{port}");
                return true;
            }

            port = FindAvailablePort();

            Console.WriteLine($"Starting paayes-mock on port #{port}...");

            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "paayes-mock",
                    Arguments = $"-http-port {port} -spec {specPath} -fixtures {fixturesPath}",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                },
            };
            try
            {
                process.Start();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error while starting paayes-mock, error message = {e.Message}");
                Environment.Exit(1);
            }

            process.BeginOutputReadLine();
            Thread.Sleep(1000);

            if (process.HasExited)
            {
                Console.Error.WriteLine($"paayes-mock terminated early, status code = {process.ExitCode}");
                Environment.Exit(1);
            }

            Console.WriteLine($"Started paayes-mock, PID = #{process.Id}");

            return true;
        }

        /// <summary>
        /// Stop the paayes-mock process if one was started.
        /// </summary>
        public static void StopPaayesMock()
        {
            if ((process == null) || process.HasExited)
            {
                return;
            }

            Console.WriteLine("Stopping paayes-mock...");
            process.Kill();
            process = null;
            port = -1;
            Console.WriteLine("Stopped paayes-mock");
        }

        /// <summary>Finds an available TCP port.</summary>
        /// <returns>The available port.</returns>
        private static int FindAvailablePort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int availablePort = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return availablePort;
        }
    }
}
