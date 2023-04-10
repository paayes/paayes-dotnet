namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public class EphemeralKeyService : Service<EphemeralKey>,
        ICreatable<EphemeralKey, EphemeralKeyCreateOptions>,
        IDeletable<EphemeralKey, EphemeralKeyDeleteOptions>
    {
        public EphemeralKeyService()
            : base(null)
        {
        }

        public EphemeralKeyService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/ephemeral_keys";

        public virtual EphemeralKey Create(EphemeralKeyCreateOptions options, RequestOptions requestOptions = null)
        {
            if (options.PaayesVersion == null)
            {
                throw new System.ArgumentException("The PaayesVersion parameter has to be set when creating an Ephemeral Key", "PaayesVersion");
            }

            // Creating an ephemeral key requires a specific API version to be set. This is handled as a parameter
            // but has to be set on the RequestOptions instead.
            requestOptions = requestOptions ?? new RequestOptions();
            requestOptions.PaayesVersion = options.PaayesVersion;

            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<EphemeralKey> CreateAsync(EphemeralKeyCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            // Creating an ephemeral key requires a specific API version to be set. This is handled as a parameter
            // but has to be set on the RequestOptions instead.
            requestOptions = requestOptions ?? new RequestOptions();
            requestOptions.PaayesVersion = options.PaayesVersion;

            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual EphemeralKey Delete(string id, EphemeralKeyDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, options, requestOptions);
        }

        public virtual Task<EphemeralKey> DeleteAsync(string id, EphemeralKeyDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.DeleteEntityAsync(id, options, requestOptions, cancellationToken);
        }
    }
}
