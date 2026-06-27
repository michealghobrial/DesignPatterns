namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerShop shop = new ComputerShop();
            ComputerBuilder builder = new GamingComputerBuilder();

            shop.ConstructComputer(builder);

            Computer computer = builder.GetComputer();
            computer.DisplaySpecifications();

            Console.WriteLine("================================================");
            ComputerBuilder builder2 = new NormalComputerBuilder();

            shop.ConstructComputer(builder2);

            Computer computer2 = builder2.GetComputer();
            computer2.DisplaySpecifications();


            Console.ReadKey();
        }
    }
}
