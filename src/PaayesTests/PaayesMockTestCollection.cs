namespace PaayesTests
{
    using Xunit;

    [CollectionDefinition("paayes-mock tests")]
    public class PaayesMockTestCollection :
        ICollectionFixture<MockHttpClientFixture>,
        ICollectionFixture<PaayesMockFixture>
    {
        // This class has no code, and is never created. Its purpose is simply to be the place to
        // apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }
}
