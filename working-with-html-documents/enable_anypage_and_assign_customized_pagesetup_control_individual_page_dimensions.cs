// Enable RenderingOptions.AnyPage and assign a customized PageSetup to control individual page dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "input.html");
            string outputDocPath = Path.Combine(Directory.GetCurrentDirectory(), "output.doc");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Load the HTML document
            using (var document = new Aspose.Html.HTMLDocument(inputHtmlPath))
            {
                // Configure DOC save options
                var options = new Aspose.Html.Saving.DocSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600));

                // Convert HTML to DOC
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputDocPath);
            }

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Input HTML: {inputHtmlPath}");
            Console.WriteLine($"Output DOC: {outputDocPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}