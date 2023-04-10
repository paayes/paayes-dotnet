namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class AccountTest : BasePaayesTest
    {
        public AccountTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/accounts/acct_123");
            var account = JsonConvert.DeserializeObject<Account>(json);
            Assert.NotNull(account);
            Assert.IsType<Account>(account);
            Assert.NotNull(account.Id);
            Assert.Equal("account", account.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "settings.branding.icon",
              "settings.branding.logo",
            };

            string json = this.GetFixture("/v1/accounts/acct_123", expansions);
            var account = JsonConvert.DeserializeObject<Account>(json);

            Assert.NotNull(account);
            Assert.IsType<Account>(account);
            Assert.NotNull(account.Id);
            Assert.Equal("account", account.Object);

            Assert.NotNull(account.Settings.Branding.Icon);
            Assert.Equal("file", account.Settings.Branding.Icon.Object);

            Assert.NotNull(account.Settings.Branding.Logo);
            Assert.Equal("file", account.Settings.Branding.Logo.Object);
        }
    }
}
