namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class AccountLinkTest : BasePaayesTest
    {
        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.account_link.json");
            var accountLink = JsonConvert.DeserializeObject<AccountLink>(json);
            Assert.NotNull(accountLink);
            Assert.IsType<AccountLink>(accountLink);
            Assert.Equal("account_link", accountLink.Object);
        }
    }
}
