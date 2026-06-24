using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern2
{
    public class SMSNotification : INotificationSender
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending SMS notification: {message}");
        }
    }
}
