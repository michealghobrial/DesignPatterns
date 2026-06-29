namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car prototypeCar = new Car
            {
                Model = "Sedan",
                Color = "Blue",
                Engine = "V6",
                Sunroof = true,
                EngineType = new Engine()
                {
                    HorsePower = 300
                }
            };


            Console.WriteLine("Original Car Configuration:");
            Console.WriteLine(prototypeCar);


            Car clonedCar = (Car)prototypeCar.Clone();

            clonedCar.EngineType.HorsePower = 500;
            clonedCar.Color = "Red";
            clonedCar.Sunroof = false;

            Console.WriteLine("\nCloned and Modified Car Configuration:");
            Console.WriteLine(clonedCar);
            Console.WriteLine(prototypeCar);

            Console.ReadKey();
        }
    }
}
