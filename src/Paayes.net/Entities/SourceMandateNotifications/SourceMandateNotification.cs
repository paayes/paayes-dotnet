namespace Paayes
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class SourceMandateNotification : PaayesEntity<SourceMandateNotification>, IHasId, IHasObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Created { get; set; } = Paayes.Infrastructure.DateTimeUtils.UnixEpoch;

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sepa_debit")]
        public SourceMandateNotificationSepaDebit SepaDebit { get; set; }
    }
}
