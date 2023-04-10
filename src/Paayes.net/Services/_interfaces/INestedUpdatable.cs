namespace Paayes
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface INestedUpdatable<TEntity, TOptions>
        where TEntity : IPaayesEntity, IHasId
        where TOptions : BaseOptions, new()
    {
        TEntity Update(string parentId, string id, TOptions updateOptions, RequestOptions requestOptions = null);

        Task<TEntity> UpdateAsync(string parentId, string id, TOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
