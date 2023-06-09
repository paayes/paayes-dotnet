// File generated from our OpenAPI spec
namespace Paayes.Terminal
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReaderUpdateOptions : BaseOptions, IHasMetadata
    {
        /// <summary>
        /// The new label of the reader.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Set of <a href="https://docs.paayes.com/api/metadata">key-value pairs</a> that you can
        /// attach to an object. This can be useful for storing additional information about the
        /// object in a structured format. Individual keys can be unset by posting an empty value to
        /// them. All keys can be unset by posting an empty value to <c>metadata</c>.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
