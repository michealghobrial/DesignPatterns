using FactoryPattern4.Factories;
using FactoryPattern4.Providers;

namespace FactoryPattern4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDocumentConverter documentConverter = new PdfConverterFactory().CreateDocumentConverter();
            documentConverter.Convert("source.docx", "output.pdf");

            Console.WriteLine("====================================");

            documentConverter = new DocxConverterFactory().CreateDocumentConverter();
            documentConverter.Convert("source.pdf", "output.docx");

            Console.WriteLine("====================================");

            documentConverter = new TxtConverterFactory().CreateDocumentConverter();
            documentConverter.Convert("source.pdf", "output.txt");

        }
    }
}