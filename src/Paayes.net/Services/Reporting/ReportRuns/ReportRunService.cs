// File generated from our OpenAPI spec
namespace Paayes.Reporting
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ReportRunService : Service<ReportRun>,
        ICreatable<ReportRun, ReportRunCreateOptions>,
        IListable<ReportRun, ReportRunListOptions>,
        IRetrievable<ReportRun, ReportRunGetOptions>
    {
        public ReportRunService()
            : base(null)
        {
        }

        public ReportRunService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/reporting/report_runs";

        public virtual ReportRun Create(ReportRunCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<ReportRun> CreateAsync(ReportRunCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual ReportRun Get(string id, ReportRunGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<ReportRun> GetAsync(string id, ReportRunGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<ReportRun> List(ReportRunListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<PaayesList<ReportRun>> ListAsync(ReportRunListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<ReportRun> ListAutoPaging(ReportRunListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual IAsyncEnumerable<ReportRun> ListAutoPagingAsync(ReportRunListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAutoPagingAsync(options, requestOptions, cancellationToken);
        }
    }
}
