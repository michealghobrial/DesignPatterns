using AbstractFactory2.Abstractions;
using AbstractFactory2.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Factories
{
    public class CreditCardPaymentFactory : IPaymentFactory
    {
        public IPaymentAuthorization CreateAuthorization()
        {
            return new CreditCardAuthorization();
        }

        public IPaymentTransfer CreateTransfer()
        {
            return new CreditCardTransfer();
        }
    }
}
