using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class CreditCardGateway : IPaymentGateway
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing ${amount} payment using Credit Card...");
        }
    }
}
