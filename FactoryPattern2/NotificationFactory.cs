using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern2
{
    public static class NotificationFactory
    {
        public static INotificationSender CreateNotification(string notificationType)
        {
            switch (notificationType.ToLower())
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SMSNotification();
                case "push":
                    return new PushNotification();
                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }
}
