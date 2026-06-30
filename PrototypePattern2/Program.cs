namespace PrototypePattern2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeProfile existingEmployee = new EmployeeProfile
            {
                Name = "John Doe",
                Address = "123 Main St, Cityville",
                Role = "Software Developer",
                Salary = 75000
            };

            Console.WriteLine("Existing Employee Profile:");
            existingEmployee.DisplayProfile();

            Console.WriteLine("-------------------------------------------");
            EmployeeProfile tempEmployee = (EmployeeProfile)existingEmployee.Clone();
            tempEmployee.Name = "Jane Smith";
            tempEmployee.Address = "456 Elm St, Cityville";

            Console.WriteLine("\nNew Temporary Employee Profile:");
            tempEmployee.DisplayProfile();

            Console.ReadKey();

        }
    }
}
