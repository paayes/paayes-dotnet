// File generated from our OpenAPI spec
namespace Paayes
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class SubscriptionPauseCollectionOptions : INestedOptions
    {
        /// <summary>
        /// The payment collection behavior for this subscription while paused. One of
        /// <c>keep_as_draft</c>, <c>mark_uncollectible</c>, or <c>void</c>.
        /// One of: <c>keep_as_draft</c>, <c>mark_uncollectible</c>, or <c>void</c>.
        /// </summary>
        [JsonProperty("behavior")]
        public string Behavior { get; set; }

        /// <summary>
        /// The time after which the subscription will resume collecting payments.
        /// </summary>
        [JsonProperty("resumes_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? ResumesAt { get; set; }
    }
}
