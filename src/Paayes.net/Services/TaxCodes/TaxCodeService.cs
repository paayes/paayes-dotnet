// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class TaxCodeService : Service<TaxCode>,
        IListable<TaxCode, TaxCodeListOptions>,
        IRetrievable<TaxCode, TaxCodeGetOptions>
    {
        public TaxCodeService()
            : base(null)
        {
        }

        public TaxCodeService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/tax_codes";

        public virtual TaxCode Get(string id, TaxCodeGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<TaxCode> GetAsync(string id, TaxCodeGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<TaxCode> List(TaxCodeListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<PaayesList<TaxCode>> ListAsync(TaxCodeListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<TaxCode> ListAutoPaging(TaxCodeListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual IAsyncEnumerable<TaxCode> ListAutoPagingAsync(TaxCodeListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAutoPagingAsync(options, requestOptions, cancellationToken);
        }
    }
}
