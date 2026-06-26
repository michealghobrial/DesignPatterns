using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Abstractions
{
    public interface IPaymentAuthorization
    {
        bool AuthorizePayment(decimal amount);
    }
}
