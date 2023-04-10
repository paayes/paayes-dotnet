// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonDocumentsPassportOptions : INestedOptions
    {
        /// <summary>
        /// One or more document ids returned by a <a
        /// href="https://docs.paayes.com/api#create_file">file upload</a> with a <c>purpose</c>
        /// value of <c>account_requirement</c>.
        /// </summary>
        [JsonProperty("files")]
        public List<string> Files { get; set; }
    }
}
