// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class SubscriptionSchedulePhaseAddInvoiceItem : PaayesEntity<SubscriptionSchedulePhaseAddInvoiceItem>
    {
        #region Expandable Price

        /// <summary>
        /// (ID of the Price)
        /// ID of the price used to generate the invoice item.
        /// </summary>
        [JsonIgnore]
        public string PriceId
        {
            get => this.InternalPrice?.Id;
            set => this.InternalPrice = SetExpandableFieldId(value, this.InternalPrice);
        }

        /// <summary>
        /// (Expanded)
        /// ID of the price used to generate the invoice item.
        ///
        /// For more information, see the <a href="https://docs.paayes.com/expand">expand documentation</a>.
        /// </summary>
        [JsonIgnore]
        public Price Price
        {
            get => this.InternalPrice?.ExpandedObject;
            set => this.InternalPrice = SetExpandableFieldObject(value, this.InternalPrice);
        }

        [JsonProperty("price")]
        [JsonConverter(typeof(ExpandableFieldConverter<Price>))]
        internal ExpandableField<Price> InternalPrice { get; set; }
        #endregion

        /// <summary>
        /// The quantity of the invoice item.
        /// </summary>
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        /// <summary>
        /// The tax rates which apply to the item. When set, the <c>default_tax_rates</c> do not
        /// apply to this item.
        /// </summary>
        [JsonProperty("tax_rates")]
        public List<TaxRate> TaxRates { get; set; }
    }
}
