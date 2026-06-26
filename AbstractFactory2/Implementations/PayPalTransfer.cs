using AbstractFactory2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Implementations
{
    public class PayPalTransfer : IPaymentTransfer
    {
        public bool Transfer(decimal amount)
        {
            Console.WriteLine($"Transferring payment of {amount} via PayPal...");
            return true; // Mocked success
        }
    }
}
