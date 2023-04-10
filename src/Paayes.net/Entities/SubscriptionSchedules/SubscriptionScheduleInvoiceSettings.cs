namespace Paayes
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class SubscriptionScheduleInvoiceSettings : PaayesEntity<SubscriptionScheduleInvoiceSettings>
    {
        [JsonProperty("days_until_due")]
        public long? DaysUntilDue { get; set; }
    }
}
