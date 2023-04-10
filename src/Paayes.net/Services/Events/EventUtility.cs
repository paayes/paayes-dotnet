namespace Paayes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Paayes.Infrastructure;

    /// <summary>
    /// This class contains utility methods to process event objects in Paayes's webhooks.
    /// </summary>
    public static class EventUtility
    {
        internal static readonly UTF8Encoding SafeUTF8
            = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        private const int DefaultTimeTolerance = 300;

        /// <summary>
        /// Parses a JSON string from a Paayes webhook into a <see cref="Event"/> object.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="throwOnApiVersionMismatch">
        /// If <c>true</c> (default), the method will throw a <see cref="PaayesException"/> if the
        /// API version of the event doesn't match Paayes.net's default API version (see
        /// <see cref="PaayesConfiguration.ApiVersion"/>).
        /// </param>
        /// <returns>The deserialized <see cref="Event"/>.</returns>
        /// <exception cref="PaayesException">
        /// Thrown if the API version of the event doesn't match Paayes.net's default API version.
        /// </exception>
        /// <remarks>
        /// This method doesn't verify <a href="https://docs.paayes.com/webhooks/signatures">webhook
        /// signatures</a>. It's recommended that you use
        /// <see cref="ConstructEvent(string, string, string, long, bool)"/> instead.
        /// </remarks>
        public static Event ParseEvent(string json, bool throwOnApiVersionMismatch = true)
        {
            var paayesEvent = JsonUtils.DeserializeObject<Event>(
                json,
                PaayesConfiguration.SerializerSettings);

            if (throwOnApiVersionMismatch &&
                paayesEvent.ApiVersion != PaayesConfiguration.ApiVersion)
            {
                throw new PaayesException(
                    $"Received event with API version {paayesEvent.ApiVersion}, but Paayes.net "
                    + $"{PaayesConfiguration.PaayesNetVersion} expects API version "
                    + $"{PaayesConfiguration.ApiVersion}. We recommend that you create a "
                    + "WebhookEndpoint with this API version. Otherwise, you can disable this "
                    + "exception by passing `throwOnApiVersionMismatch: false` to "
                    + "`Paayes.EventUtility.ParseEvent` or `Paayes.EventUtility.ConstructEvent`, "
                    + "but be wary that objects may be incorrectly deserialized.");
            }

            return paayesEvent;
        }

        /// <summary>
        /// Parses a JSON string from a Paayes webhook into a <see cref="Event"/> object, while
        /// verifying the <a href="https://docs.paayes.com/webhooks/signatures">webhook's
        /// signature</a>.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="paayesSignatureHeader">
        /// The value of the <c>Paayes-Signature</c> header from the webhook request.
        /// </param>
        /// <param name="secret">The webhook endpoint's signing secret.</param>
        /// <param name="tolerance">The time tolerance, in seconds (default 300).</param>
        /// <param name="throwOnApiVersionMismatch">
        /// If <c>true</c> (default), the method will throw a <see cref="PaayesException"/> if the
        /// API version of the event doesn't match Paayes.net's default API version (see
        /// <see cref="PaayesConfiguration.ApiVersion"/>).
        /// </param>
        /// <returns>The deserialized <see cref="Event"/>.</returns>
        /// <exception cref="PaayesException">
        /// Thrown if the signature verification fails for any reason, of if the API version of the
        /// event doesn't match Paayes.net's default API version.
        /// </exception>
        public static Event ConstructEvent(
            string json,
            string paayesSignatureHeader,
            string secret,
            long tolerance = DefaultTimeTolerance,
            bool throwOnApiVersionMismatch = true)
        {
            return ConstructEvent(
                json,
                paayesSignatureHeader,
                secret,
                tolerance,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                throwOnApiVersionMismatch);
        }

        /// <summary>
        /// Parses a JSON string from a Paayes webhook into a <see cref="Event"/> object, while
        /// verifying the <a href="https://docs.paayes.com/webhooks/signatures">webhook's
        /// signature</a>.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="paayesSignatureHeader">
        /// The value of the <c>Paayes-Signature</c> header from the webhook request.
        /// </param>
        /// <param name="secret">The webhook endpoint's signing secret.</param>
        /// <param name="tolerance">The time tolerance, in seconds.</param>
        /// <param name="utcNow">The timestamp to use for the current time.</param>
        /// <param name="throwOnApiVersionMismatch">
        /// If <c>true</c> (default), the method will throw a <see cref="PaayesException"/> if the
        /// API version of the event doesn't match Paayes.net's default API version (see
        /// <see cref="PaayesConfiguration.ApiVersion"/>).
        /// </param>
        /// <returns>The deserialized <see cref="Event"/>.</returns>
        /// <exception cref="PaayesException">
        /// Thrown if the signature verification fails for any reason, of if the API version of the
        /// event doesn't match Paayes.net's default API version.
        /// </exception>
        public static Event ConstructEvent(
            string json,
            string paayesSignatureHeader,
            string secret,
            long tolerance,
            long utcNow,
            bool throwOnApiVersionMismatch = true)
        {
            ValidateSignature(json, paayesSignatureHeader, secret, tolerance, utcNow);
            return ParseEvent(json, throwOnApiVersionMismatch);
        }

        public static void ValidateSignature(string json, string paayesSignatureHeader, string secret, long tolerance = DefaultTimeTolerance)
        {
            ValidateSignature(json, paayesSignatureHeader, secret, tolerance, DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }

        public static void ValidateSignature(string json, string paayesSignatureHeader, string secret, long tolerance, long utcNow)
        {
            var signatureItems = ParsePaayesSignature(paayesSignatureHeader);
            var signature = string.Empty;

            try
            {
                signature = ComputeSignature(secret, signatureItems["t"].FirstOrDefault(), json);
            }
            catch (EncoderFallbackException ex)
            {
                throw new PaayesException(
                    "The webhook cannot be processed because the signature cannot be safely calculated.",
                    ex);
            }

            if (!IsSignaturePresent(signature, signatureItems["v1"]))
            {
                throw new PaayesException(
                    "The signature for the webhook is not present in the Paayes-Signature header.");
            }

            var webhookUtc = Convert.ToInt32(signatureItems["t"].FirstOrDefault());

            if (Math.Abs(utcNow - webhookUtc) > tolerance)
            {
                throw new PaayesException(
                    "The webhook cannot be processed because the current timestamp is outside of the allowed tolerance.");
            }
        }

        private static ILookup<string, string> ParsePaayesSignature(string paayesSignatureHeader)
        {
            return paayesSignatureHeader.Trim()
                .Split(',')
                .Select(item => item.Trim().Split(new[] { '=' }, 2))
                .ToLookup(item => item[0], item => item[1]);
        }

        private static bool IsSignaturePresent(string signature, IEnumerable<string> signatures)
        {
            return signatures.Any(key => StringUtils.SecureEquals(key, signature));
        }

        private static string ComputeSignature(string secret, string timestamp, string payload)
        {
            var secretBytes = SafeUTF8.GetBytes(secret);
            var payloadBytes = SafeUTF8.GetBytes($"{timestamp}.{payload}");

            using (var cryptographer = new HMACSHA256(secretBytes))
            {
                var hash = cryptographer.ComputeHash(payloadBytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }
    }
}
