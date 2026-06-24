using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern3.Providers
{
    public class AmazonS3Provider : IStorageProvider
    {
        public void SaveFile(string fileName, byte[] fileData)
        {
            Console.WriteLine($"Saving {fileName} to Amazon S3...");
            // Logic for saving file to Amazon S3
        }
        public byte[] RetrieveFile(string fileName)
        {
            Console.WriteLine($"Retrieving {fileName} from Amazon S3...");
            // Logic for retrieving file from Amazon S3
            return new byte[0];  // Sample return
        }
    }
}
