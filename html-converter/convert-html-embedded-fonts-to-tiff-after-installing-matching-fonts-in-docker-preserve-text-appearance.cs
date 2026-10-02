// Convert HTML with embedded fonts to TIFF after installing matching fonts in Docker to preserve text appearance.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with an embedded font reference
            string htmlContent = "<!DOCTYPE html><html><head><style>@font-face{font-family:'MyFont';src:url('myfont.ttf') format('truetype');}body{font-family:'MyFont';font-size:24px;}</style></head><body>Hello, world!</body></html>";
            string baseUri = "about:blank";

            // Load HTML document from string content
            var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Configure image save options for TIFF
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Output file path
            string outputPath = "output.tiff";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Convert HTML to TIFF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}