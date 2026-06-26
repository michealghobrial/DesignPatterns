using AbstractFactory3.Factories;
using AbstractFactory3.Services;

namespace AbstractFactory3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Order for Modern Furniture:");
            var modernFactory = new ModernFurnitureFactory();
            var modernService = new FurnitureService(modernFactory);
            modernService.ShowProducts();

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("\nOrder for Vintage Furniture:");
            var vintageFactory = new VintageFurnitureFactory();
            var VintageService = new FurnitureService(vintageFactory);
            VintageService.ShowProducts();
        }
    }
}
