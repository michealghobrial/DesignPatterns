using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern4.Providers
{
    public class TxtConverter : IDocumentConverter
    {
        public void Convert(string inputFile, string outputFile)
        {
            Console.WriteLine($"Converting {inputFile} to TXT and saving as {outputFile}.");
        }
    }
}
