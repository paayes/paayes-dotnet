// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class BalanceService : Service<Balance>,
        ISingletonRetrievable<Balance>
    {
        public BalanceService()
            : base(null)
        {
        }

        public BalanceService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/balance";

        public virtual Balance Get(RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Get, this.ClassUrl(), null, requestOptions);
        }

        public virtual Task<Balance> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Get, this.ClassUrl(), null, requestOptions, cancellationToken);
        }
    }
}
