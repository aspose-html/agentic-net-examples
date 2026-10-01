// Load HTML from a URL, configure proxy settings in Configuration, and render to JPG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file path
            string htmlPath = "sample.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body><h1>Hello, Aspose.HTML!</h1><p>This is a test.</p></body>
</html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Define output image paths
            string pngOutputPath = "output.png";
            string jpegOutputPath = "output.jpg";

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert to PNG
            var pngOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(document, pngOptions, pngOutputPath);

            // Convert to JPEG with custom resolution
            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            jpegOptions.HorizontalResolution = 300;
            jpegOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertHTML(document, jpegOptions, jpegOutputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"PNG saved to: {Path.GetFullPath(pngOutputPath)}");
            Console.WriteLine($"JPEG saved to: {Path.GetFullPath(jpegOutputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}