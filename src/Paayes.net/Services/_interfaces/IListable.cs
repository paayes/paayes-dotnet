namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IListable<TEntity, TOptions>
        where TEntity : IPaayesEntity, IHasId
        where TOptions : ListOptions, new()
    {
        PaayesList<TEntity> List(TOptions listOptions = null, RequestOptions requestOptions = null);

        Task<PaayesList<TEntity>> ListAsync(TOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        IEnumerable<TEntity> ListAutoPaging(TOptions listOptions = null, RequestOptions requestOptions = null);

        IAsyncEnumerable<TEntity> ListAutoPagingAsync(TOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
