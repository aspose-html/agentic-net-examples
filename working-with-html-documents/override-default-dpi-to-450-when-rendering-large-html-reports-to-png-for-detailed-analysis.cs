// Override default DPI to 450 when rendering large HTML reports to PNG for detailed analysis.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "report.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalHtml = "<!DOCTYPE html><html><head><title>Sample Report</title></head><body><h1>Report Title</h1><p>This is a sample HTML report.</p></body></html>";
                File.WriteAllText(inputPath, minimalHtml);
            }

            // Read HTML content
            string htmlContent = File.ReadAllText(inputPath);
            string baseUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;

            // Configure image save options with DPI 450
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 450;
            options.VerticalResolution = 450;

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"HTML report has been rendered to PNG with 450 DPI at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}