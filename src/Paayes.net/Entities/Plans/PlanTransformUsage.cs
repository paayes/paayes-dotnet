// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PlanTransformUsage : PaayesEntity<PlanTransformUsage>
    {
        /// <summary>
        /// Divide usage by this number.
        /// </summary>
        [JsonProperty("divide_by")]
        public long DivideBy { get; set; }

        /// <summary>
        /// After division, either round the result <c>up</c> or <c>down</c>.
        /// One of: <c>down</c>, or <c>up</c>.
        /// </summary>
        [JsonProperty("round")]
        public string Round { get; set; }
    }
}
