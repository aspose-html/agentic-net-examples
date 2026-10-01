// Convert an HTML file to PDF quickly using the ConvertHTML method with default settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output PDF file paths
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Set PDF save options (default options are sufficient for this example)
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF and save to the specified output path
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed successfully. PDF saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}