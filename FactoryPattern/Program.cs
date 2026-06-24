namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the payment gateway (PayPal, Stripe, CreditCard): ");
            string gatewayName = Console.ReadLine();

            try
            {
                IPaymentGateway paymentGateway = PaymentGatewayFactory.CreatePaymentGateway(gatewayName);
                paymentGateway.ProcessPayment(1500);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while processing payment", ex);
            }
            Console.ReadKey();
        }
    }
}
