using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public static class PaymentGatewayFactory
    {
        public static IPaymentGateway CreatePaymentGateway(string gatewayName)
        {

            switch (gatewayName.ToLower())
            {
                case "paymob":
                    return new PaymobGateway();
                case "stripe":
                    return new StripeGateway();
                case "creditcard":
                    return new CreditCardGateway();
                default:
                    throw new ArgumentException("Invalid payment gateway specified");
            }
        }
    }
}
