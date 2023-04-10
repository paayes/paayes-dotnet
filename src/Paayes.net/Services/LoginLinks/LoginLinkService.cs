// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginLinkService : ServiceNested<LoginLink>,
        INestedCreatable<LoginLink, LoginLinkCreateOptions>
    {
        public LoginLinkService()
            : base(null)
        {
        }

        public LoginLinkService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/accounts/{PARENT_ID}/login_links";

        public virtual LoginLink Create(string parentId, LoginLinkCreateOptions options = null, RequestOptions requestOptions = null)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public virtual Task<LoginLink> CreateAsync(string parentId, LoginLinkCreateOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateNestedEntityAsync(parentId, options, requestOptions, cancellationToken);
        }
    }
}
