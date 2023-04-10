namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISingletonRetrievable<TEntity>
        where TEntity : IPaayesEntity
    {
        TEntity Get(RequestOptions requestOptions = null);

        Task<TEntity> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
