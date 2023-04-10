namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class SourceTransactionService : ServiceNested<SourceTransaction>,
        INestedListable<SourceTransaction, SourceTransactionsListOptions>
    {
        public SourceTransactionService()
            : base(null)
        {
        }

        public SourceTransactionService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/sources/{PARENT_ID}/source_transactions";

        public virtual PaayesList<SourceTransaction> List(string sourceId, SourceTransactionsListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(sourceId, options, requestOptions);
        }

        public virtual Task<PaayesList<SourceTransaction>> ListAsync(string sourceId, SourceTransactionsListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListNestedEntitiesAsync(sourceId, options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<SourceTransaction> ListAutoPaging(string sourceId, SourceTransactionsListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntitiesAutoPaging(sourceId, options, requestOptions);
        }

        public virtual IAsyncEnumerable<SourceTransaction> ListAutoPagingAsync(string sourceId, SourceTransactionsListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListNestedEntitiesAutoPagingAsync(sourceId, options, requestOptions, cancellationToken);
        }
    }
}
