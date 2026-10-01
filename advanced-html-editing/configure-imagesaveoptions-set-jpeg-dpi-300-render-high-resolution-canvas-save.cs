// Configure ImageSaveOptions to set JPEG DPI to 300, then render a high‑resolution canvas and save.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options with 300 DPI
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to high‑resolution JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}