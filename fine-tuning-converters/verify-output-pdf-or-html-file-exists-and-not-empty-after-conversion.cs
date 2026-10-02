// After each conversion, verify that the output PDF or HTML file exists and is not empty before proceeding.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            if (!File.Exists(outputPath) || new FileInfo(outputPath).Length == 0)
            {
                throw new Exception("Conversion verification failed: output PDF is missing or empty.");
            }

            Console.WriteLine("Conversion succeeded. PDF file created at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}