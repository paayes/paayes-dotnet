namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface INestedListable<TEntity, TOptions>
        where TEntity : IPaayesEntity, IHasId
        where TOptions : ListOptions, new()
    {
        PaayesList<TEntity> List(string parentId, TOptions listOptions = null, RequestOptions requestOptions = null);

        Task<PaayesList<TEntity>> ListAsync(string parentId, TOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        IEnumerable<TEntity> ListAutoPaging(string parentId, TOptions listOptions = null, RequestOptions requestOptions = null);

        IAsyncEnumerable<TEntity> ListAutoPagingAsync(string parentId, TOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
