// Load an HTML file from disk using HTMLDocument constructor and convert to PDF with default options.

using System;
using System.IO;

namespace HTMLToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.html";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}