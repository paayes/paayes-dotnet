namespace PaayesTests
{
    using Paayes;
    using Paayes.Infrastructure.FormEncoding;
    using Xunit;

    public class PaymentIntentConfirmOptionsTest : BasePaayesTest
    {
        [Fact]
        public void SerializeObjectProperly()
        {
            var options_bool = new PaymentIntentConfirmOptions
            {
                OffSession = true,
            };

            Assert.Equal("off_session=True", FormEncoder.CreateQueryString(options_bool));
        }
    }
}
