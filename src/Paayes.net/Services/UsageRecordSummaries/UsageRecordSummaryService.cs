// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class UsageRecordSummaryService : ServiceNested<UsageRecordSummary>,
        INestedListable<UsageRecordSummary, UsageRecordSummaryListOptions>
    {
        public UsageRecordSummaryService()
            : base(null)
        {
        }

        public UsageRecordSummaryService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/subscription_items/{PARENT_ID}/usage_record_summaries";

        public virtual PaayesList<UsageRecordSummary> List(string parentId, UsageRecordSummaryListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(parentId, options, requestOptions);
        }

        public virtual Task<PaayesList<UsageRecordSummary>> ListAsync(string parentId, UsageRecordSummaryListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListNestedEntitiesAsync(parentId, options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<UsageRecordSummary> ListAutoPaging(string parentId, UsageRecordSummaryListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntitiesAutoPaging(parentId, options, requestOptions);
        }

        public virtual IAsyncEnumerable<UsageRecordSummary> ListAutoPagingAsync(string parentId, UsageRecordSummaryListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListNestedEntitiesAutoPagingAsync(parentId, options, requestOptions, cancellationToken);
        }
    }
}
