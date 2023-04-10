// File generated from our OpenAPI spec
namespace Paayes
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class LoginLink : PaayesEntity<LoginLink>, IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Created { get; set; } = Paayes.Infrastructure.DateTimeUtils.UnixEpoch;

        /// <summary>
        /// The URL for the login link.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
