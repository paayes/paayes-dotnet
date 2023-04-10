namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDeletable<TEntity, TOptions>
        where TEntity : IPaayesEntity, IHasId
        where TOptions : BaseOptions, new()
    {
        TEntity Delete(string id, TOptions options = null, RequestOptions requestOptions = null);

        Task<TEntity> DeleteAsync(string id, TOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
