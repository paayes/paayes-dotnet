namespace PaayesTests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that lists (as in <see cref="List{T}"/>) are used instead of
    /// arrays (<c>[]</c>) in Paayes entities and options classes.
    /// </summary>
    public class UseListsInsteadOfArrays : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one array type. Please use List<> instead.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from PaayesEntity or implement INestedOptions
            var paayesClasses = GetSubclassesOf(typeof(PaayesEntity));
            paayesClasses.AddRange(GetClassesWithInterface(typeof(INestedOptions)));

            foreach (Type paayesClass in paayesClasses)
            {
                foreach (PropertyInfo property in paayesClass.GetProperties())
                {
                    var propType = property.PropertyType;

                    // Skip properties that don't have a `JsonProperty` attribute
                    var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                    if (attribute == null)
                    {
                        continue;
                    }

                    // Skip non-array types
                    if (!propType.GetTypeInfo().IsArray)
                    {
                        continue;
                    }

                    results.Add($"{paayesClass.Name}.{property.Name}");
                }
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
