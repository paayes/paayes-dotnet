using System;

namespace Paayes.net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PaayesConfiguration.ApiKey = "sk_test_UiiMzY3NDE3Mzg3NDc0MDIzMjQsKEq00Eq01Uii58082";

            var options = new CustomerCreateOptions
            {
                Email = "test@paayes.com",
                Balance = 0,
                InvoicePrefix = "825ADB9",
                Name = "Test Client",               
                Description = "Sample user",
                TaxExempt = "none"
            };
            var service = new CustomerService();
            var c = service.Create(options);
        }
    }
}