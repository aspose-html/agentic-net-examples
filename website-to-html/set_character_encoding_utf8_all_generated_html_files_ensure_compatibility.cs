// Set character encoding to UTF‑8 for all generated HTML files to ensure compatibility.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string minimalHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, minimalHtml, Encoding.UTF8);
            }

            // Read HTML content from the file
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("utf-8"));

            // Load the HTML content into an Aspose.Html.HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set PDF save options (default options are sufficient for this example)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert the HTML document to PDF and save to the output path
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion succeeded. PDF saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}