// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class ChargePaymentMethodDetailsBancontact : PaayesEntity<ChargePaymentMethodDetailsBancontact>
    {
        /// <summary>
        /// Bank code of bank associated with the bank account.
        /// </summary>
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        /// <summary>
        /// Name of the bank associated with the bank account.
        /// </summary>
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// Bank Identifier Code of the bank associated with the bank account.
        /// </summary>
        [JsonProperty("bic")]
        public string Bic { get; set; }

        #region Expandable GeneratedSepaDebit

        /// <summary>
        /// (ID of the PaymentMethod)
        /// The ID of the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        /// </summary>
        [JsonIgnore]
        public string GeneratedSepaDebitId
        {
            get => this.InternalGeneratedSepaDebit?.Id;
            set => this.InternalGeneratedSepaDebit = SetExpandableFieldId(value, this.InternalGeneratedSepaDebit);
        }

        /// <summary>
        /// (Expanded)
        /// The ID of the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        ///
        /// For more information, see the <a href="https://docs.paayes.com/expand">expand documentation</a>.
        /// </summary>
        [JsonIgnore]
        public PaymentMethod GeneratedSepaDebit
        {
            get => this.InternalGeneratedSepaDebit?.ExpandedObject;
            set => this.InternalGeneratedSepaDebit = SetExpandableFieldObject(value, this.InternalGeneratedSepaDebit);
        }

        [JsonProperty("generated_sepa_debit")]
        [JsonConverter(typeof(ExpandableFieldConverter<PaymentMethod>))]
        internal ExpandableField<PaymentMethod> InternalGeneratedSepaDebit { get; set; }
        #endregion

        #region Expandable GeneratedSepaDebitMandate

        /// <summary>
        /// (ID of the Mandate)
        /// The mandate for the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        /// </summary>
        [JsonIgnore]
        public string GeneratedSepaDebitMandateId
        {
            get => this.InternalGeneratedSepaDebitMandate?.Id;
            set => this.InternalGeneratedSepaDebitMandate = SetExpandableFieldId(value, this.InternalGeneratedSepaDebitMandate);
        }

        /// <summary>
        /// (Expanded)
        /// The mandate for the SEPA Direct Debit PaymentMethod which was generated by this Charge.
        ///
        /// For more information, see the <a href="https://docs.paayes.com/expand">expand documentation</a>.
        /// </summary>
        [JsonIgnore]
        public Mandate GeneratedSepaDebitMandate
        {
            get => this.InternalGeneratedSepaDebitMandate?.ExpandedObject;
            set => this.InternalGeneratedSepaDebitMandate = SetExpandableFieldObject(value, this.InternalGeneratedSepaDebitMandate);
        }

        [JsonProperty("generated_sepa_debit_mandate")]
        [JsonConverter(typeof(ExpandableFieldConverter<Mandate>))]
        internal ExpandableField<Mandate> InternalGeneratedSepaDebitMandate { get; set; }
        #endregion

        /// <summary>
        /// Last four characters of the IBAN.
        /// </summary>
        [JsonProperty("iban_last4")]
        public string IbanLast4 { get; set; }

        /// <summary>
        /// Preferred language of the Bancontact authorization page that the customer is redirected
        /// to. Can be one of <c>en</c>, <c>de</c>, <c>fr</c>, or <c>nl</c>.
        /// One of: <c>de</c>, <c>en</c>, <c>fr</c>, or <c>nl</c>.
        /// </summary>
        [JsonProperty("preferred_language")]
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// Owner's verified full name. Values are verified or provided by Bancontact directly (if
        /// supported) at the time of authorization or settlement. They cannot be set or mutated.
        /// </summary>
        [JsonProperty("verified_name")]
        public string VerifiedName { get; set; }
    }
}
