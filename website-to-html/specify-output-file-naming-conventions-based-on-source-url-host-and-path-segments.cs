// Specify output file naming conventions based on source URL host and path segments.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Source URL and HTML content
            string sourceUrl = "https://example.com/path/to/page.html";
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Create HTML document with base URI
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, sourceUrl))
            {
                // Configure image save options
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Build output file name based on URL host and path segments
                Uri uri = new Uri(sourceUrl);
                string host = uri.Host;
                string[] pathSegments = uri.AbsolutePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string safePath = string.Join("_", pathSegments);
                string fileName = $"{host}_{safePath}.jpg";

                string outputPath = Path.Combine(outputDir, fileName);

                // Convert HTML to image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}