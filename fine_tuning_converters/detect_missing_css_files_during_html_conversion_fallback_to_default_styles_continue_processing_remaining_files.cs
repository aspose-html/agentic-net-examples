// Detect missing CSS files during HTML conversion, fallback to default styles, and continue processing remaining files.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Directory containing HTML files to process
            string inputFolder = "input";
            // Ensure the folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"Input folder '{inputFolder}' does not exist.");
                return;
            }

            // Process each HTML file in the folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                try
                {
                    // Load HTML content from file
                    string htmlContent = File.ReadAllText(htmlPath);

                    // Create HTMLDocument from the content (rule usage)
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

                    // Prepare conversion options (rule usage)
                    XpsSaveOptions options = new XpsSaveOptions();

                    // Attempt conversion to XPS
                    string outputPath = Path.ChangeExtension(htmlPath, ".xps");
                    Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                }
                catch (Exception ex)
                {
                    // If conversion fails (e.g., missing CSS), fallback to default styling
                    Console.WriteLine($"Conversion failed for '{htmlPath}': {ex.Message}");
                    Console.WriteLine("Applying fallback with default CSS.");

                    // Read original HTML and wrap it with minimal default style
                    string originalHtml = File.ReadAllText(htmlPath);
                    string fallbackHtml = $"<html><head><style>body{{font-family:Arial;}}</style></head><body>{originalHtml}</body></html>";

                    // Create a new document with fallback style (rule usage)
                    Aspose.Html.HTMLDocument fallbackDocument = new Aspose.Html.HTMLDocument(fallbackHtml);

                    // Use default options for fallback conversion
                    XpsSaveOptions fallbackOptions = new XpsSaveOptions();

                    // Save fallback conversion result
                    string fallbackOutput = Path.ChangeExtension(htmlPath, "_fallback.xps");
                    Converter.ConvertHTML(fallbackDocument, fallbackOptions, fallbackOutput);
                    Console.WriteLine($"Fallback conversion succeeded: '{fallbackOutput}'.");
                }
            }
        }
        catch (Exception e)
        {
            // General error handling
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}