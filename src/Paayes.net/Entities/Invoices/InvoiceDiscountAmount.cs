namespace Paayes
{
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class InvoiceDiscountAmount : PaayesEntity<InvoiceDiscountAmount>
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        #region Expandable Discount

        [JsonIgnore]
        public string DiscountId
        {
            get => this.InternalDiscount?.Id;
            set => this.InternalDiscount = SetExpandableFieldId(value, this.InternalDiscount);
        }

        [JsonIgnore]
        public Discount Discount
        {
            get => this.InternalDiscount?.ExpandedObject;
            set => this.InternalDiscount = SetExpandableFieldObject(value, this.InternalDiscount);
        }

        [JsonProperty("discount")]
        [JsonConverter(typeof(ExpandableFieldConverter<Discount>))]
        internal ExpandableField<Discount> InternalDiscount { get; set; }
        #endregion
    }
}
