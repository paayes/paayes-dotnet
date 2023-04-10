namespace PaayesTests.Infrastructure.TestData
{
    using Paayes;

    public class TestService : Service<Charge>
    {
        public TestService()
            : base(null)
        {
        }

        public override string BasePath => "/charges";
    }
}
