using AbstractFactory.Factories;
using AbstractFactory.Repositories;


namespace AbstractFactory.Services
{
    public class DataService
    {
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;

        // Constructor accepts abstract factory
        // This allows switching between SQL and MongoDB without changing this class
        public DataService(IRepositoryFactory factory)
        {
            userRepository = factory.CreateUserRepository();
            orderRepository = factory.CreateOrderRepository();
        }

        // Business logic methods that use the repositories
        public void DisplayUserData()
        {
            Console.WriteLine("--- DataService: Fetching User Data ---");
            userRepository.GetUser();
            Console.WriteLine();
        }

        public void DisplayOrderData()
        {
            Console.WriteLine("--- DataService: Fetching Order Data ---");
            orderRepository.GetOrder();
            Console.WriteLine();
        }

        public void ProcessUserOrder()
        {
            Console.WriteLine("--- DataService: Processing User Order ---");
            userRepository.GetUser();
            orderRepository.GetOrder();
            Console.WriteLine("Order processed successfully!");
            Console.WriteLine();
        }
    }

}
