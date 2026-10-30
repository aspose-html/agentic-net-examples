// Set ImageSaveOptions JPEG quality to 95 percent for high‑resolution JPEG output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output JPEG file paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure image save options for high‑resolution JPEG output
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300; // DPI
            options.VerticalResolution = 300;   // DPI
            // Note: Aspose.HTML does not provide a JPEG quality property for ImageSaveOptions.

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG using the configured options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}