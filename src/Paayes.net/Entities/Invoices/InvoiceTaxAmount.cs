namespace Paayes
{
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class InvoiceTaxAmount : PaayesEntity<InvoiceTaxAmount>
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("inclusive")]
        public bool Inclusive { get; set; }

        #region Expandable TaxRate

        [JsonIgnore]
        public string TaxRateId
        {
            get => this.InternalTaxRate?.Id;
            set => this.InternalTaxRate = SetExpandableFieldId(value, this.InternalTaxRate);
        }

        [JsonIgnore]
        public TaxRate TaxRate
        {
            get => this.InternalTaxRate?.ExpandedObject;
            set => this.InternalTaxRate = SetExpandableFieldObject(value, this.InternalTaxRate);
        }

        [JsonProperty("tax_rate")]
        [JsonConverter(typeof(ExpandableFieldConverter<TaxRate>))]
        internal ExpandableField<TaxRate> InternalTaxRate { get; set; }
        #endregion
    }
}
