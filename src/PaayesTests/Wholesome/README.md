## Wholesome tests

Unlike regular tests that check the behavior of the library, wholesome tests
contain checks on the state of the Paayes.net codebase and are there to
prevent programming errors and enforce consistency. They rely heavily on
reflection.

For example, `AllPaayesObjectClassesPresentInDictionary` ensures that when a
model class is added for a new API resource, developers don't forget to add
the new type in `PaayesTypeRegistry`.
