namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class FileService : Service<File>,
        ICreatable<File, FileCreateOptions>,
        IListable<File, FileListOptions>,
        IRetrievable<File, FileGetOptions>
    {
        public FileService()
            : base(null)
        {
        }

        public FileService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/files";

        public virtual File Create(FileCreateOptions options, RequestOptions requestOptions = null)
        {
            requestOptions = this.SetupRequestOptionsForFilesRequest(requestOptions);
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<File> CreateAsync(FileCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            requestOptions = this.SetupRequestOptionsForFilesRequest(requestOptions);
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual File Get(string id, FileGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<File> GetAsync(string id, FileGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<File> List(FileListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<PaayesList<File>> ListAsync(FileListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<File> ListAutoPaging(FileListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual IAsyncEnumerable<File> ListAutoPagingAsync(FileListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAutoPagingAsync(options, requestOptions, cancellationToken);
        }

        private RequestOptions SetupRequestOptionsForFilesRequest(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            if (requestOptions.BaseUrl == null)
            {
                requestOptions.BaseUrl = this.Client.FilesBase;
            }

            return requestOptions;
        }
    }
}
