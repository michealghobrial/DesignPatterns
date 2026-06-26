using AbstractFactory2.Abstractions;
using AbstractFactory2.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Factories
{
    public class PaypalPaymentFactory : IPaymentFactory
    {
        public IPaymentAuthorization CreateAuthorization()
        {
            return new PayPalAuthorization();
        }

        public IPaymentTransfer CreateTransfer()
        {
            return new PayPalTransfer();
        }
    }
}
