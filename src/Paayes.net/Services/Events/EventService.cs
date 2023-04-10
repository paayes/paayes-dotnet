// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class EventService : Service<Event>,
        IListable<Event, EventListOptions>,
        IRetrievable<Event, EventGetOptions>
    {
        public EventService()
            : base(null)
        {
        }

        public EventService(IPaayesClient client)
            : base(client)
        {
        }

        public override string BasePath => "/api/v1/events";

        public virtual Event Get(string id, EventGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        public virtual Task<Event> GetAsync(string id, EventGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual PaayesList<Event> List(EventListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<PaayesList<Event>> ListAsync(EventListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Event> ListAutoPaging(EventListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual IAsyncEnumerable<Event> ListAutoPagingAsync(EventListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAutoPagingAsync(options, requestOptions, cancellationToken);
        }
    }
}
