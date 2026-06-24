using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern4.Providers
{
    public class DocxConverter : IDocumentConverter
    {
        public void Convert(string inputFile, string outputFile)
        {
            Console.WriteLine($"Converting {inputFile} to DOCX and saving as {outputFile}.");
        }
    }
}
