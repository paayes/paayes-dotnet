namespace PaayesTests
{
    using System;
    using Paayes;
    using Xunit;

    public class PaayesTypeRegistryTest : BasePaayesTest
    {
        [Fact]
        public void GetConcreteType()
        {
            Type type = null;

            // When provided with a concrete type, it is directly returned and the object string is
            // ignored.
            type = typeof(Card);
            Assert.Equal(typeof(Card), PaayesTypeRegistry.GetConcreteType(type, "bank_account"));

            // When provided with an interface, the concrete type is deduced from the object string
            type = typeof(IExternalAccount);
            Assert.Equal(typeof(BankAccount), PaayesTypeRegistry.GetConcreteType(type, "bank_account"));

            // When provided with an interface and no concrete type is known for the object string,
            // it returns null
            type = typeof(IExternalAccount);
            Assert.Null(PaayesTypeRegistry.GetConcreteType(type, "unknown_object"));

            // When provided with an interface and a concrete type is known for the object string
            // but is incompatible with the interface, it returns null
            type = typeof(IExternalAccount);
            Assert.Null(PaayesTypeRegistry.GetConcreteType(type, "source"));
        }
    }
}
