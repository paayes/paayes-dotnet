// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public class AccountLinkService : Service<AccountLink>,
        ICreatable<AccountLink, AccountLinkCreateOptions>
    {
        public AccountLinkService()
            : base(null)
        {
        }

        public AccountLinkService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/account_links";

        public virtual AccountLink Create(AccountLinkCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<AccountLink> CreateAsync(AccountLinkCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }
    }
}
