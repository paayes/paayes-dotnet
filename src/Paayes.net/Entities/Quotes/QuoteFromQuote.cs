// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class QuoteFromQuote : PaayesEntity<QuoteFromQuote>
    {
        /// <summary>
        /// Whether this quote is a revision of a different quote.
        /// </summary>
        [JsonProperty("is_revision")]
        public bool IsRevision { get; set; }

        #region Expandable Quote

        /// <summary>
        /// (ID of the Quote)
        /// The quote that was cloned.
        /// </summary>
        [JsonIgnore]
        public string QuoteId
        {
            get => this.InternalQuote?.Id;
            set => this.InternalQuote = SetExpandableFieldId(value, this.InternalQuote);
        }

        /// <summary>
        /// (Expanded)
        /// The quote that was cloned.
        ///
        /// For more information, see the <a href="https://docs.paayes.com/expand">expand documentation</a>.
        /// </summary>
        [JsonIgnore]
        public Quote Quote
        {
            get => this.InternalQuote?.ExpandedObject;
            set => this.InternalQuote = SetExpandableFieldObject(value, this.InternalQuote);
        }

        [JsonProperty("quote")]
        [JsonConverter(typeof(ExpandableFieldConverter<Quote>))]
        internal ExpandableField<Quote> InternalQuote { get; set; }
        #endregion
    }
}
