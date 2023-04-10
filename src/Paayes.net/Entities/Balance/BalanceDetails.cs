namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BalanceDetails : PaayesEntity<BalanceDetails>
    {
        [JsonProperty("available")]
        public List<BalanceAmount> Available { get; set; }
    }
}
