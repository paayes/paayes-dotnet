namespace Paayes
{
    using System;
    using System.Net;

    public class PaayesException : Exception
    {
        public PaayesException()
        {
        }

        public PaayesException(string message)
            : base(message)
        {
        }

        public PaayesException(string message, Exception err)
            : base(message, err)
        {
        }

        public PaayesException(HttpStatusCode httpStatusCode, PaayesError paayesError, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.PaayesError = paayesError;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public PaayesError PaayesError { get; set; }

        public PaayesResponse PaayesResponse { get; set; }
    }
}
