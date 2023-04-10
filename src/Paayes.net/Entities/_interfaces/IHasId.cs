namespace Paayes
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that identifies entities returned by Paayes that have an `id` attribute.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        string Id { get; set; }
    }
}
