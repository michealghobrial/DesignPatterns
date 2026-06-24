using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern3.Providers
{
    public class GoogleCloudStorageProvider : IStorageProvider
    {
        public void SaveFile(string fileName, byte[] fileData)
        {
            Console.WriteLine($"Saving {fileName} to Google Cloud Storage...");
            // Logic for saving file to Google Cloud Storage
        }
        public byte[] RetrieveFile(string fileName)
        {
            Console.WriteLine($"Retrieving {fileName} from Google Cloud Storage...");
            // Logic for retrieving file from Google Cloud Storage
            return new byte[0];  // Sample return
        }
    }
}
