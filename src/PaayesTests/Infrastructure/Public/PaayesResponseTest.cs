namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http.Headers;
    using Paayes;
    using Xunit;

    public class PaayesResponseTest : BasePaayesTest
    {
        public PaayesResponseTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        /* Most of PaayesResponse's methods are helpers for accessing headers. Unfortunately,
         * HttpResponseHeaders is a sealed class with no public constructor, which makes it
         * ~impossible to write unit tests for PaayesResponse. This is why we rely on real
         * requests and fetch PaayesResponse instances attached to resources.
         */

        [Fact]
        public void Date()
        {
            var response = new AccountService(this.PaayesClient).GetSelf().PaayesResponse;

            Assert.NotNull(response.Date);
        }

        [Fact]
        public void IdempotencyKey_Present()
        {
            var requestOptions = new RequestOptions { IdempotencyKey = "idempotency_key" };
            var response = new AccountService(this.PaayesClient).GetSelf(requestOptions).PaayesResponse;

            Assert.Equal("idempotency_key", response.IdempotencyKey);
        }

        [Fact]
        public void IdempotencyKey_Absent()
        {
            var response = new AccountService(this.PaayesClient).GetSelf().PaayesResponse;

            Assert.Null(response.IdempotencyKey);
        }

        [Fact]
        public void RequestId()
        {
            var response = new AccountService(this.PaayesClient).GetSelf().PaayesResponse;

            Assert.NotNull(response.RequestId);
        }
    }
}
