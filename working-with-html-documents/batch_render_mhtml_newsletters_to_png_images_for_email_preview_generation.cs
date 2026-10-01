// Batch render a set of MHTML newsletters to PNG images for email preview generation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output PNG file paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            // Configure image save options for PNG format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed. Output saved to \"{outputPath}\".");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}