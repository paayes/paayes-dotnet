namespace Paayes
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class SourceService : Service<Source>,
        ICreatable<Source, SourceCreateOptions>,
        IRetrievable<Source, SourceGetOptions>,
        IUpdatable<Source, SourceUpdateOptions>,
        INestedListable<Source, SourceListOptions>
    {
        public SourceService()
            : base(null)
        {
        }

        public SourceService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/sources";

        public virtual Source Attach(string parentId, SourceAttachOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<Source>(HttpMethod.Post, $"/api/customers/{parentId}/sources", options, requestOptions);
        }

        public virtual Task<Source> AttachAsync(string parentId, SourceAttachOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Source>(HttpMethod.Post, $"/api/customers/{parentId}/sources", options, requestOptions, cancellationToken);
        }

        public virtual Source Create(SourceCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<Source> CreateAsync(SourceCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual Source Detach(string parentId, string id, SourceDetachOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<Source>(HttpMethod.Delete, $"/api/customers/{parentId}/sources/{id}", null, requestOptions);
        }

        public virtual Task<Source> DetachAsync(string parentId, string id, SourceDetachOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Source>(HttpMethod.Delete, $"/api/customers/{parentId}/sources/{id}", null, requestOptions, cancellationToken);
        }

        public virtual Source Get(string id, SourceGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<Source> GetAsync(string id, SourceGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<Source> List(string parentId, SourceListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<PaayesList<Source>>(HttpMethod.Get, $"/api/customers/{parentId}/sources", options ?? new SourceListOptions(), requestOptions);
        }

        public virtual Task<PaayesList<Source>> ListAsync(string parentId, SourceListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<PaayesList<Source>>(HttpMethod.Get, $"/api/customers/{parentId}/sources", options ?? new SourceListOptions(), requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Source> ListAutoPaging(string parentId, SourceListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListRequestAutoPaging<Source>($"/api/customers/{parentId}/sources", options ?? new SourceListOptions(), requestOptions);
        }

        public virtual IAsyncEnumerable<Source> ListAutoPagingAsync(string parentId, SourceListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListRequestAutoPagingAsync<Source>($"/api/customers/{parentId}/sources", options ?? new SourceListOptions(), requestOptions, cancellationToken);
        }

        public virtual Source Update(string id, SourceUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, options, requestOptions);
        }

        public virtual Task<Source> UpdateAsync(string id, SourceUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.UpdateEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual Source Verify(string id, SourceVerifyOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<Source>(HttpMethod.Post, $"{this.InstanceUrl(id)}/verify", options, requestOptions);
        }

        public virtual Task<Source> VerifyAsync(string id, SourceVerifyOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Source>(HttpMethod.Post, $"{this.InstanceUrl(id)}/verify", options, requestOptions, cancellationToken);
        }
    }
}
