// Convert an HTML file to DOCX while preserving layout using ConvertHTML method.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output DOC file paths
            string sourcePath = "sample.html";
            string outputPath = "output.doc";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Set DOC save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Convert HTML to DOC
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion succeeded. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}