using AbstractFactory2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Implementations
{
    public class CreditCardAuthorization : IPaymentAuthorization
    {
        public bool AuthorizePayment(decimal amount)
        {
            Console.WriteLine($"Authorizing payment of {amount} via Credit Card...");
            return true; // Mocked success
        }
    }
}
