namespace Paayes
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class DiscountService : Service<Discount>
    {
        public DiscountService()
            : base(null)
        {
        }

        public DiscountService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => null;

        public virtual Discount DeleteCustomerDiscount(string customerId, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Delete, $"/api/customers/{customerId}/discount", null, requestOptions);
        }

        public virtual Task<Discount> DeleteCustomerDiscountAsync(string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Delete, $"/api/customers/{customerId}/discount", null, requestOptions, cancellationToken);
        }

        public virtual Discount DeleteSubscriptionDiscount(string subscriptionId, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Delete, $"/api/subscriptions/{subscriptionId}/discount", null, requestOptions);
        }

        public virtual Task<Discount> DeleteSubscriptionDiscountAsync(string subscriptionId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Delete, $"/api/subscriptions/{subscriptionId}/discount", null, requestOptions, cancellationToken);
        }
    }
}
