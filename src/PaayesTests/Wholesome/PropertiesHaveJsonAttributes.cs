namespace PaayesTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that all properties in Paayes entities and options classes are
    /// annotated with either <see cref="JsonPropertyAttribute"/> or
    /// <see cref="JsonIgnoreAttribute"/>.
    /// </summary>
    public class PropertiesHaveJsonAttributes : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one property lacking a Json*Attribute. Please add either a "
            + "[JsonProperty(\"name\")] or a [JsonIgnore] attribute.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from PaayesEntity or implement INestedOptions
            var paayesClasses = GetSubclassesOf(typeof(PaayesEntity));
            paayesClasses.AddRange(GetClassesWithInterface(typeof(INestedOptions)));

            foreach (var paayesClass in paayesClasses)
            {
                foreach (var property in paayesClass.GetProperties())
                {
                    var hasJsonAttribute = false;

                    foreach (var attribute in property.GetCustomAttributes())
                    {
                        if (attribute.GetType() == typeof(JsonPropertyAttribute)
                            || attribute.GetType() == typeof(JsonIgnoreAttribute)
                            || attribute.GetType() == typeof(JsonExtensionDataAttribute))
                        {
                            hasJsonAttribute = true;
                            break;
                        }
                    }

                    if (hasJsonAttribute)
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
