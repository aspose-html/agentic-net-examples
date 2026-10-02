// Override default DPI to 72 when generating low‑resolution PNG previews of HTML content.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "preview.png";

            // Ensure sample HTML file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Read HTML content and base URI
            string htmlContent = File.ReadAllText(inputPath);
            string baseUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;

            // Configure image save options with DPI 72
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            // Convert HTML to PNG preview
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"PNG preview generated at: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}