using AbstractFactory2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Services
{
    public class PaymentService
    {
        private readonly IPaymentAuthorization _paymentAuthorization;
        private readonly IPaymentTransfer _paymentTransfer;

        public PaymentService(IPaymentFactory paymentFactory)
        {
            _paymentAuthorization = paymentFactory.CreateAuthorization();
            _paymentTransfer = paymentFactory.CreateTransfer();
        }

        public bool ProcessPayment(decimal amount)
        {
            if (_paymentAuthorization.AuthorizePayment(amount))
                return _paymentTransfer.Transfer(amount);

            return false;
        }
    }
}
