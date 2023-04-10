// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentIntentNextActionWechatPayRedirectToIosApp : PaayesEntity<PaymentIntentNextActionWechatPayRedirectToIosApp>
    {
        /// <summary>
        /// An universal link that redirect to Wechat Pay APP.
        /// </summary>
        [JsonProperty("native_url")]
        public string NativeUrl { get; set; }
    }
}
