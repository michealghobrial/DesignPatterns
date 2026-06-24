using FactoryPattern4.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern4.Factories
{
    public class DocxConverterFactory : DocumentConverterFactory
    {
        public override IDocumentConverter CreateDocumentConverter()
        {
            return new DocxConverter();
        }
    }
}
