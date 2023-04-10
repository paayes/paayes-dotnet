namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class EphemeralKeyServiceTest : BasePaayesTest
    {
        private const string EphemeralKeyId = "ephkey_123";

        private readonly EphemeralKeyService service;
        private readonly EphemeralKeyCreateOptions createOptions;

        public EphemeralKeyServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new EphemeralKeyService(this.PaayesClient);

            this.createOptions = new EphemeralKeyCreateOptions
            {
                Customer = "cus_123",
                PaayesVersion = PaayesConfiguration.ApiVersion,
            };
        }

        [Fact]
        public void Create()
        {
            var ephemeralKey = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/ephemeral_keys");
            Assert.NotNull(ephemeralKey);
            Assert.Equal("ephemeral_key", ephemeralKey.Object);
            Assert.NotNull(ephemeralKey.RawJson);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var ephemeralKey = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/ephemeral_keys");
            Assert.NotNull(ephemeralKey);
            Assert.Equal("ephemeral_key", ephemeralKey.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(EphemeralKeyId);
            this.AssertRequest(HttpMethod.Delete, "/v1/ephemeral_keys/ephkey_123");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(EphemeralKeyId);
            this.AssertRequest(HttpMethod.Delete, "/v1/ephemeral_keys/ephkey_123");
            Assert.NotNull(deleted);
        }
    }
}
