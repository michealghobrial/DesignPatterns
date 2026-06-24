using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public interface IPaymentGateway
    {
        void ProcessPayment(double amount);
    }
}
