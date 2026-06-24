using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class PaymobGateway : IPaymentGateway
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing ${amount} payment through Paymob...");
        }
    }
}
