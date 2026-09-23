// Convert an HTML document containing a canvas element to JPEG using ImageSaveOptions.

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
            string outputPath = "output.jpg";

            // Create a minimal HTML file with a canvas element
            string htmlContent = "<!DOCTYPE html><html><body><canvas id='c' width='200' height='200' style='border:1px solid #000000;'></canvas></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure image save options
            var options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Load the HTML document
            var document = new HTMLDocument(htmlPath);

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}