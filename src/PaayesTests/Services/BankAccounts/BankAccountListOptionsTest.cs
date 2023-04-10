namespace PaayesTests
{
    using Paayes;
    using Paayes.Infrastructure.FormEncoding;
    using Xunit;

    public class BankAccountListOptionsTest : BasePaayesTest
    {
        [Fact]
        public void SerializeObjectProperly()
        {
            var options = new BankAccountListOptions();

            Assert.Equal("object=bank_account", FormEncoder.CreateQueryString(options));
        }
    }
}
