// Specify output file naming conventions based on source URL host and path segments.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Source URL
            string sourceUrl = "https://example.com/path/to/page.html";

            // Derive file name from host and path segments
            Uri uri = new Uri(sourceUrl);
            string host = uri.Host;
            string path = uri.AbsolutePath.Trim('/');
            string safePath = string.IsNullOrEmpty(path) ? "" : path.Replace('/', '_');
            string fileName = string.IsNullOrEmpty(safePath) ? host : host + "_" + safePath;

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Full output path with .jpeg extension
            string outputPath = Path.Combine(outputDir, fileName + ".jpeg");

            // Load HTML document from URL
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl))
            {
                // Configure image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert HTML to JPEG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}