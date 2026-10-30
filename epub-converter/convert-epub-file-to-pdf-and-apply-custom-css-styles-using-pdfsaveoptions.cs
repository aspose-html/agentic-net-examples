// Convert an EPUB file to PDF and apply custom CSS styles using PdfSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output PDF file path
            string outputPath = Path.Combine("output", "result.pdf");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open EPUB file stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Create configuration and set custom CSS
                Configuration configuration = new Configuration();
                IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
                userAgent.UserStyleSheet = "body { font-family: Arial; color: #333333; }";

                // Set PDF save options
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert EPUB to PDF with custom CSS
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, configuration, pdfOptions, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}