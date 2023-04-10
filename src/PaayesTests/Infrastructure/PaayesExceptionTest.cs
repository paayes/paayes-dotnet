namespace PaayesTests
{
    using System.Threading.Tasks;
    using Paayes;
    using Xunit;

    public class PaayesExceptionTest : BasePaayesTest
    {
        public PaayesExceptionTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public async Task SetsPaayesResponse()
        {
            // This test assumes that `POST /v1/payment_intents` has at least one required param,
            // and so will throw an exception if we provide zero params.
            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
            {
                await new PaymentIntentService(this.PaayesClient)
                    .CreateAsync(new PaymentIntentCreateOptions());
            });

            Assert.NotNull(exception);
            Assert.NotNull(exception.PaayesError);
            Assert.NotNull(exception.PaayesError.PaayesResponse);
        }
    }
}
