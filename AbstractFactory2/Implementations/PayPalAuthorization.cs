using AbstractFactory2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Implementations
{
    public class PayPalAuthorization : IPaymentAuthorization
    {
        public bool AuthorizePayment(decimal amount)
        {
            Console.WriteLine($"Authorizing payment of {amount} via PayPal...");
            return true; // Mocked success
        }
    }
}
