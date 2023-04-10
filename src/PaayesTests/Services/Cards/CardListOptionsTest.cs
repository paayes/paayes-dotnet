namespace PaayesTests
{
    using Paayes;
    using Paayes.Infrastructure.FormEncoding;
    using Xunit;

    public class CardListOptionsTest : BasePaayesTest
    {
        [Fact]
        public void SerializeObjectProperly()
        {
            var options = new CardListOptions();

            Assert.Equal("object=card", FormEncoder.CreateQueryString(options));
        }
    }
}
