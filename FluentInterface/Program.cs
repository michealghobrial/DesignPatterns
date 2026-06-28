namespace FluentInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string query = new QueryBuilder()
                .Select("Name , Age")
                .From("Users")
                .Where("Age > 21")
                .Build();

            Console.WriteLine("Query: " + query);
        }
    }
}
