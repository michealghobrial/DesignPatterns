using System.Runtime.CompilerServices;

namespace FluentInterface2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var order = new ShoppingCartBuilder()
                .AddProduct("Laptop", 1000m)
                .AddProduct("Mouse", 50m)
                .RemoveProduct("Mouse")
                .AddProduct("Keyboard", 70m)
                .Checkout();

            foreach (var item in order.Products)
                Console.WriteLine($"{item.Name}: {item.Price} EGP");

            Console.WriteLine("============================");
            Console.WriteLine($"Total Price: {order.TotalPrice}");

            // Outputs: Total Price: 1070
            Console.ReadKey();
        }
    }
}
