using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern4.Providers
{
    public interface IDocumentConverter
    {
        void Convert(string inputFile, string outputFile);
    }
}
