// Render HTML to PNG with DPI set to 300 for high‑resolution image output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Configure image save options with 300 DPI
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to PNG with the specified DPI
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}