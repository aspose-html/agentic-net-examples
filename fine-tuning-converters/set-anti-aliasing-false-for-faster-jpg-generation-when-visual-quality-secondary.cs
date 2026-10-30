// Set ImageRenderingOptions.AntiAliasing to false for faster JPG generation when visual quality is secondary.

using System;
using System.IO;
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
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Sample</h1><p>This is a test.</p></body></html>");
            }

            // Output JPEG file path
            string outputPath = "output.jpg";

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = false;
            // Optional: set resolution for faster processing
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}