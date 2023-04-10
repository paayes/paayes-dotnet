namespace Paayes
{
    /// <summary>
    /// Resources that implement this interface can be used as external accounts, i.e. they can
    /// be attached to a Paayes account to receive payouts.
    /// <para>Possible concrete classes:</para>
    /// <list type="bullet">
    /// <item>
    /// <description><see cref="BankAccount" /></description>
    /// </item>
    /// <item>
    /// <description><see cref="Card" /></description>
    /// </item>
    /// </list>
    /// </summary>
    public interface IExternalAccount : IPaayesEntity, IHasId, IHasObject
    {
        Account Account { get; }

        string AccountId { get; }
    }
}
