using AbstractFactory2.Abstractions;
using AbstractFactory2.Factories;
using AbstractFactory2.Services;

namespace AbstractFactory2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing payment using Credit Card:");
            IPaymentFactory creditCardFactory = new CreditCardPaymentFactory();
            var creditCardService = new PaymentService(creditCardFactory);
            creditCardService.ProcessPayment(100.00M);

            Console.WriteLine("=============================================");

            var paypalFactory = new PaypalPaymentFactory();
            var paypalService = new PaymentService(paypalFactory);
            paypalService.ProcessPayment(100.00M);

            Console.ReadKey();
        }
    }
}
