namespace PaayesTests
{
    using System;

    /// <summary>
    /// Represents errors that are related to tests themselves rather than the
    /// features under test.
    /// </summary>
    public class PaayesTestException : Exception
    {
        public PaayesTestException()
        {
        }

        public PaayesTestException(string message)
            : base(message)
        {
        }
    }
}
