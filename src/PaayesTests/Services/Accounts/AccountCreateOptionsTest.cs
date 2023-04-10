namespace PaayesTests
{
    using Paayes;
    using Paayes.Infrastructure.FormEncoding;
    using Xunit;

    public class AccountCreateOptionsTest : BasePaayesTest
    {
        [Fact]
        public void Serialize()
        {
            var options = new AccountCreateOptions
            {
                Individual = new AccountIndividualOptions
                {
                    FirstName = "first name",
                    LastName = "last name",
                },
            };

            Assert.Equal(
                "individual[first_name]=first+name&individual[last_name]=last+name",
                FormEncoder.CreateQueryString(options));
        }
    }
}
