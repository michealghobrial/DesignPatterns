using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern2
{
    public interface INotificationSender
    {
        void SendNotification(string message);
    }
}
