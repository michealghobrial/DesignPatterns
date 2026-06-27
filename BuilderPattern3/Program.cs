using System.Text;

namespace BuilderPattern3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpRequestMessage request = new HttpRequestBuilder()
                .WithMethod(HttpMethod.Post)
                .WithUri(new Uri("https://api.example.com/items"))
                .WithHeader("Authorization", "Bearer my_token")
                .Build();

            using (var client = new HttpClient())
            {
                var response = client.SendAsync(request).Result;
                Console.WriteLine(response);
            }

            Console.ReadKey();
        }
    }
}
