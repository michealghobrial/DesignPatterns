using AbstractFactory.Factories;
using AbstractFactory.Services;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     ABSTRACT FACTORY PATTERN DEMONSTRATION            ║");
            Console.WriteLine("║     Database Repository Example                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Demonstrate switching between different database families
            DemonstrateAbstractFactory();

            Console.WriteLine("\n" + new string('=', 56));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void DemonstrateAbstractFactory()
        {
            // ============================================
            // SCENARIO 1: Using SQL Database Family
            // ============================================

            Console.WriteLine("SCENARIO 1: Application configured to use SQL Database");
            Console.WriteLine(new string('-', 56));

            // Create SQL factory
            IRepositoryFactory sqlFactory = new SqlRepositoryFactory();

            // Pass factory to client - client doesn't know it's SQL
            DataService sqlDataService = new DataService(sqlFactory);

            // Client uses repositories through abstract interfaces
            sqlDataService.DisplayUserData();
            sqlDataService.DisplayOrderData();
            sqlDataService.ProcessUserOrder();

            Console.WriteLine();

            // ============================================
            // SCENARIO 2: Using MongoDB Family
            // ============================================

            Console.WriteLine("SCENARIO 2: Application configured to use MongoDB");
            Console.WriteLine(new string('-', 56));

            // Create MongoDB factory
            IRepositoryFactory mongoFactory = new MongoRepositoryFactory();

            // Pass factory to client - client doesn't know it's MongoDB
            DataService mongoDataService = new DataService(mongoFactory);

            // Same client code, different database implementation!
            mongoDataService.DisplayUserData();
            mongoDataService.DisplayOrderData();
            mongoDataService.ProcessUserOrder();

            Console.WriteLine();

            // ============================================
            // SCENARIO 3: Runtime Configuration
            // ============================================

            Console.WriteLine("SCENARIO 3: Runtime Database Selection");
            Console.WriteLine(new string('-', 56));
            Console.WriteLine("Choose database type:");
            Console.WriteLine("1. SQL Server");
            Console.WriteLine("2. MongoDB");
            Console.Write("Enter choice (1 or 2): ");

            string choice = Console.ReadLine();

            // Factory is chosen at runtime based on configuration
            IRepositoryFactory factory = GetFactoryByChoice(choice);

            DataService dataService = new DataService(factory);

            Console.WriteLine();
            dataService.ProcessUserOrder();

            // ============================================
            // KEY BENEFITS DEMONSTRATED
            // ============================================

            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              KEY BENEFITS OF ABSTRACT FACTORY          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("✓ Client (DataService) works with abstractions only");
            Console.WriteLine("✓ Easy to switch between SQL and MongoDB");
            Console.WriteLine("✓ Family consistency: User and Order repos from same DB");
            Console.WriteLine("✓ No changes to client code when adding new databases");
            Console.WriteLine("✓ Open/Closed Principle: Open for extension, closed for modification");
            Console.WriteLine();
        }

        // Helper method to get factory based on user choice or configuration
        static IRepositoryFactory GetFactoryByChoice(string choice)
        {
            return choice switch
            {
                "1" => new SqlRepositoryFactory(),
                "2" => new MongoRepositoryFactory(),
                _ => new SqlRepositoryFactory() // Default to SQL
            };
        }

        // Alternative: Get factory from configuration file
        static IRepositoryFactory GetFactoryFromConfiguration()
        {
            // In real application, read from appsettings.json or environment variable
            string databaseType = GetDatabaseTypeFromConfig();

            return databaseType.ToLower() switch
            {
                "sql" => new SqlRepositoryFactory(),
                "mongodb" => new MongoRepositoryFactory(),
                _ => throw new InvalidOperationException($"Unknown database type: {databaseType}")
            };
        }

        // Simulates reading configuration
        static string GetDatabaseTypeFromConfig()
        {
            // In real app: ConfigurationManager.AppSettings["DatabaseType"]
            // Or: _configuration["DatabaseSettings:Type"]
            return "SQL"; // Default value
        }
    }
}
