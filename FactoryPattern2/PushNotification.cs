using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern2
{
    public class PushNotification : INotificationSender
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending PUSH notification: {message}");
        }
    }
}
