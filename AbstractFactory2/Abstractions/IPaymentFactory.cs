using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory2.Abstractions
{
    public interface IPaymentFactory
    {
        IPaymentAuthorization CreateAuthorization();
        IPaymentTransfer CreateTransfer();
    }
}
