// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ExternalAccountService : ServiceNested<IExternalAccount>,
        INestedCreatable<IExternalAccount, ExternalAccountCreateOptions>,
        INestedDeletable<IExternalAccount, ExternalAccountDeleteOptions>,
        INestedListable<IExternalAccount, ExternalAccountListOptions>,
        INestedRetrievable<IExternalAccount, ExternalAccountGetOptions>,
        INestedUpdatable<IExternalAccount, ExternalAccountUpdateOptions>
    {
        public ExternalAccountService()
            : base(null)
        {
        }

        public ExternalAccountService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/accounts/{PARENT_ID}/external_accounts";

        public virtual IExternalAccount Create(string parentId, ExternalAccountCreateOptions options = null, RequestOptions requestOptions = null)
        {
            return this.CreateNestedEntity(parentId, options, requestOptions);
        }

        public virtual Task<IExternalAccount> CreateAsync(string parentId, ExternalAccountCreateOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateNestedEntityAsync(parentId, options, requestOptions, cancellationToken);
        }

        public virtual IExternalAccount Delete(string parentId, string id, ExternalAccountDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.DeleteNestedEntity(parentId, id, options, requestOptions);
        }

        public virtual Task<IExternalAccount> DeleteAsync(string parentId, string id, ExternalAccountDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.DeleteNestedEntityAsync(parentId, id, options, requestOptions, cancellationToken);
        }

        public virtual IExternalAccount Get(string parentId, string id, ExternalAccountGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetNestedEntity(parentId, id, options, requestOptions);
        }

        public virtual Task<IExternalAccount> GetAsync(string parentId, string id, ExternalAccountGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetNestedEntityAsync(parentId, id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<IExternalAccount> List(string parentId, ExternalAccountListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(parentId, options, requestOptions);
        }

        public virtual Task<PaayesList<IExternalAccount>> ListAsync(string parentId, ExternalAccountListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListNestedEntitiesAsync(parentId, options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<IExternalAccount> ListAutoPaging(string parentId, ExternalAccountListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntitiesAutoPaging(parentId, options, requestOptions);
        }

        public virtual IAsyncEnumerable<IExternalAccount> ListAutoPagingAsync(string parentId, ExternalAccountListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListNestedEntitiesAutoPagingAsync(parentId, options, requestOptions, cancellationToken);
        }

        public virtual IExternalAccount Update(string parentId, string id, ExternalAccountUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateNestedEntity(parentId, id, options, requestOptions);
        }

        public virtual Task<IExternalAccount> UpdateAsync(string parentId, string id, ExternalAccountUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.UpdateNestedEntityAsync(parentId, id, options, requestOptions, cancellationToken);
        }
    }
}
