// Configure ImageSaveOptions for PNG output with antialiasing enabled to improve visual quality.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Configure image save options for PNG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed successfully. Image saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}