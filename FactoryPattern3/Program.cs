using FactoryPattern3.Factories;
using FactoryPattern3.Providers;

namespace FactoryPattern3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string fileName = "test.txt";
            byte[] fileData = System.Text.Encoding.UTF8.GetBytes("Hello World!");


            IStorageProvider azureFactory = new AzureBlobFactory().CreateStorageProvider();
            azureFactory.SaveFile(fileName, fileData);
            azureFactory.RetrieveFile(fileName);

            Console.WriteLine("----------------------------------");

            IStorageProvider AmazonS3Factory = new AmazonS3Factory().CreateStorageProvider();
            AmazonS3Factory.SaveFile(fileName, fileData);
            AmazonS3Factory.RetrieveFile(fileName);

            Console.WriteLine("----------------------------------");

            IStorageProvider GoogleCloudFactory = new GoogleCloudStorageFactory().CreateStorageProvider();
            GoogleCloudFactory.SaveFile(fileName, fileData);
            GoogleCloudFactory.RetrieveFile(fileName);

            Console.ReadKey();
        }
    }
}
