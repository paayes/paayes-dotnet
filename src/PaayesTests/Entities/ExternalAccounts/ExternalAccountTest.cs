namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class ExternalAccountTest : BasePaayesTest
    {
        public ExternalAccountTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/accounts/acct_123/external_accounts/ba_123");
            var externalAccount = JsonConvert.DeserializeObject<IExternalAccount>(
                json,
                PaayesConfiguration.SerializerSettings);
            Assert.NotNull(externalAccount);
            Assert.IsType<BankAccount>(externalAccount);
            Assert.Equal("bank_account", externalAccount.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "account",
            };

            string json = this.GetFixture("/v1/accounts/acct_123/external_accounts/ba_123", expansions);
            var externalAccount = JsonConvert.DeserializeObject<IExternalAccount>(
                json,
                PaayesConfiguration.SerializerSettings);
            Assert.NotNull(externalAccount);
            Assert.IsType<BankAccount>(externalAccount);
            Assert.Equal("bank_account", externalAccount.Object);

            Assert.NotNull(externalAccount.Account);
            Assert.Equal("account", externalAccount.Account.Object);
        }
    }
}
