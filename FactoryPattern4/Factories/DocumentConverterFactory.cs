using FactoryPattern4.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern4.Factories
{
    public abstract class DocumentConverterFactory
    {
        public abstract IDocumentConverter CreateDocumentConverter();

        public void Convert(string inputFile, string outputFile)
        {
            IDocumentConverter documentConverter = CreateDocumentConverter();
            documentConverter.Convert(inputFile, outputFile);
        }
    }
}
