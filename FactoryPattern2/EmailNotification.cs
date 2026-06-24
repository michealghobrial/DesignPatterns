using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern2
{
    public class EmailNotification : INotificationSender
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending EMAIL notification: {message}");
        }
    }
}
