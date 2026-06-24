using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern4.Providers
{
    public class PdfConverter : IDocumentConverter
    {
        public void Convert(string inputFile, string outputFile)
        {
            Console.WriteLine($"Converting {inputFile} to PDF and saving as {outputFile}.");
        }
    }
}
