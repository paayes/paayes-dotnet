// File generated from our OpenAPI spec
namespace Paayes.Identity
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class VerificationSessionOptionsDocument : PaayesEntity<VerificationSessionOptionsDocument>
    {
        /// <summary>
        /// Array of strings of allowed identity document types. If the provided identity document
        /// isn’t one of the allowed types, the verification check will fail with a
        /// document_type_not_allowed error code.
        /// </summary>
        [JsonProperty("allowed_types")]
        public List<string> AllowedTypes { get; set; }

        /// <summary>
        /// Collect an ID number and perform an <a
        /// href="https://docs.paayes.com/identity/verification-checks?type=id-number">ID number
        /// check</a> with the document’s extracted name and date of birth.
        /// </summary>
        [JsonProperty("require_id_number")]
        public bool RequireIdNumber { get; set; }

        /// <summary>
        /// Disable image uploads, identity document images have to be captured using the device’s
        /// camera.
        /// </summary>
        [JsonProperty("require_live_capture")]
        public bool RequireLiveCapture { get; set; }

        /// <summary>
        /// Capture a face image and perform a <a
        /// href="https://docs.paayes.com/identity/verification-checks?type=selfie">selfie check</a>
        /// comparing a photo ID and a picture of your user’s face. <a
        /// href="https://docs.paayes.com/identity/selfie">Learn more</a>.
        /// </summary>
        [JsonProperty("require_matching_selfie")]
        public bool RequireMatchingSelfie { get; set; }
    }
}
