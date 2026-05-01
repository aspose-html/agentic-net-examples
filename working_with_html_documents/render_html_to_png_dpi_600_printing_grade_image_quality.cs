// Render HTML to PNG with DPI set to 600 for printing‑grade image quality.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file and output PNG file paths
            string htmlPath = "input.html";
            string outputPath = "output.png";

            // Configure PNG output with 600 DPI resolution
            var options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 600;
            options.VerticalResolution = 600;

            // Load the HTML document
            var document = new HTMLDocument(htmlPath);

            // Convert HTML to PNG using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}