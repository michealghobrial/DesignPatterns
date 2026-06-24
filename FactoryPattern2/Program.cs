namespace FactoryPattern2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INotificationSender notificationSender;

            notificationSender = NotificationFactory.CreateNotification("Email");
            notificationSender.SendNotification("This is an email notification!");

            Console.WriteLine("===============================");
            notificationSender = NotificationFactory.CreateNotification("SMS");
            notificationSender.SendNotification("This is an sms message");

            Console.WriteLine("===============================");
            notificationSender = NotificationFactory.CreateNotification("Push");
            notificationSender.SendNotification("This is a push notification");

            Console.ReadKey();
        }
    }
}
