// Use Converter.RenderTo with PdfDevice to generate a PDF that includes JavaScript alerts from the source HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with JavaScript alert
            string htmlContent = "<!DOCTYPE html><html><head><script>alert('Hello from JavaScript');</script></head><body><h1>Sample Page</h1></body></html>";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Configure to allow script execution
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load HTML document with the configuration
            var document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML document to PDF
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            // Clean up
            document.Dispose();

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}