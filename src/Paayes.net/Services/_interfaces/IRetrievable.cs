namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRetrievable<TEntity, TOptions>
        where TEntity : IPaayesEntity, IHasId
        where TOptions : BaseOptions, new()
    {
        TEntity Get(string id, TOptions retrieveOptions = null, RequestOptions requestOptions = null);

        Task<TEntity> GetAsync(string id, TOptions retrieveOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
