namespace Paayes
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that identifies all entities returned by Paayes.
    /// </summary>
    public interface IPaayesEntity
    {
        PaayesResponse PaayesResponse { get; set; }
    }
}
