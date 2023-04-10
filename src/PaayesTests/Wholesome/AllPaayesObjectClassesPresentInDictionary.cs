namespace PaayesTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Paayes;
    using Xunit;

    /// <summary>
    /// This test checks that all Paayes object classes (i.e. model classes that implement
    /// <see cref="Paayes.IHasObject" />) have an entry in the
    /// <see cref="Paayes.PaayesTypeRegistry.ObjectsToTypes" /> dictionary.
    /// </summary>
    public class AllPaayesObjectClassesPresentInDictionary : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one model class missing in ObjectsToTypes dictionary";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all PaayesEntity subclasses that implement IHasObject
            var modelClasses = GetSubclassesOf(typeof(PaayesEntity))
                .Intersect(GetClassesWithInterface(typeof(IHasObject)));

            foreach (Type modelClass in modelClasses)
            {
                // Skip types present in dictionary
                if (PaayesTypeRegistry.ObjectsToTypes.Any(kv => kv.Value == modelClass))
                {
                    continue;
                }

                // PaayesList is a generic type that is handled separately
                if (modelClass == typeof(PaayesList<>))
                {
                    continue;
                }

                results.Add(modelClass.Name);
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
