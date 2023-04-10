namespace PaayesTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Paayes;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that all Paayes entity and options classes implement the
    /// <c>IHasX</c> interfaces when they have matching properties.
    /// </summary>
    public class DontForgetEntityType : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one class with an incorrect base type.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from PaayesEntity
            var paayesClasses = GetSubclassesOf(typeof(PaayesEntity));

            foreach (Type paayesClass in paayesClasses)
            {
                var baseType = paayesClass.GetTypeInfo().BaseType;

                // Skip the generic version of PaayesEntity or AddressJapan as it inherits from
                // Address and is an exception in the library
                if (paayesClass == typeof(PaayesEntity<>) || paayesClass.Name == "AddressJapan")
                {
                    continue;
                }

                if (!baseType.GetTypeInfo().IsGenericType ||
                    baseType.GetGenericTypeDefinition() != typeof(PaayesEntity<>))
                {
                    results.Add($"{paayesClass.Name} inherits from {baseType.Name} instead of PaayesEntity<{paayesClass.Name}>");
                    continue;
                }

                var typeParam = baseType.GetTypeInfo().GetGenericArguments()[0];
                if (typeParam != paayesClass)
                {
                    results.Add($"{paayesClass.Name} inherits from PaayesEntity<{typeParam.Name}> instead of PaayesEntity<{paayesClass.Name}>");
                    continue;
                }
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
