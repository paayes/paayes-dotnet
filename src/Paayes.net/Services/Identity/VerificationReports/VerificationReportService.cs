// File generated from our OpenAPI spec
namespace Paayes.Identity
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class VerificationReportService : Service<VerificationReport>,
        IListable<VerificationReport, VerificationReportListOptions>,
        IRetrievable<VerificationReport, VerificationReportGetOptions>
    {
        public VerificationReportService()
            : base(null)
        {
        }

        public VerificationReportService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/identity/verification_reports";

        public virtual VerificationReport Get(string id, VerificationReportGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<VerificationReport> GetAsync(string id, VerificationReportGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<VerificationReport> List(VerificationReportListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<PaayesList<VerificationReport>> ListAsync(VerificationReportListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<VerificationReport> ListAutoPaging(VerificationReportListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual IAsyncEnumerable<VerificationReport> ListAutoPagingAsync(VerificationReportListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAutoPagingAsync(options, requestOptions, cancellationToken);
        }
    }
}
