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
    public class DontForgetIHasInterfaces : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one missing interface.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from PaayesEntity or implement INestedOptions
            var paayesClasses = GetSubclassesOf(typeof(PaayesEntity));
            paayesClasses.AddRange(GetClassesWithInterface(typeof(INestedOptions)));

            foreach (Type paayesClass in paayesClasses)
            {
                var interfaces = paayesClass.GetInterfaces();

                foreach (PropertyInfo property in paayesClass.GetProperties())
                {
                    // Check for IHasId
                    if ((property.Name == "Id") && (property.PropertyType == typeof(string)))
                    {
                        if (!interfaces.Contains(typeof(IHasId)))
                        {
                            results.Add($"{paayesClass.Name} is missing IHasId");
                        }
                    }

                    // Check for IHasObject
                    if ((property.Name == "Object") && (property.PropertyType == typeof(string)))
                    {
                        if (!interfaces.Contains(typeof(IHasObject)))
                        {
                            results.Add($"{paayesClass.Name} is missing IHasObject");
                        }
                    }

                    // Check for IHasMetadata
                    if ((property.Name == "Metadata") && (property.PropertyType == typeof(Dictionary<string, string>)))
                    {
                        if (!interfaces.Contains(typeof(IHasMetadata)))
                        {
                            results.Add($"{paayesClass.Name} is missing IHasMetadata");
                        }
                    }
                }
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
