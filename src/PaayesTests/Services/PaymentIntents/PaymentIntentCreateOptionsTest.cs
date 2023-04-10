namespace PaayesTests
{
    using Paayes;
    using Paayes.Infrastructure.FormEncoding;
    using Xunit;

    public class PaymentIntentCreateOptionsTest : BasePaayesTest
    {
        [Fact]
        public void SerializeObjectProperly()
        {
            var options_bool = new PaymentIntentCreateOptions
            {
                OffSession = true,
            };

            Assert.Equal("off_session=True", FormEncoder.CreateQueryString(options_bool));
        }
    }
}
