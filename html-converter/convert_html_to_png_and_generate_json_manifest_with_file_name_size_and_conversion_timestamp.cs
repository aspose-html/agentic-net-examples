// Convert HTML to PNG and generate a JSON manifest containing file name, size, and conversion timestamp.

using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string pngPath = "output.png";
            string manifestPath = "manifest.json";

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Write HTML to file
            File.WriteAllText(htmlPath, htmlContent);

            // Create image save options for PNG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pngPath);

            // Get PNG file info
            var fileInfo = new FileInfo(pngPath);

            // Build manifest object
            var manifest = new
            {
                FileName = fileInfo.Name,
                Size = fileInfo.Length,
                Timestamp = fileInfo.CreationTimeUtc
            };

            // Serialize manifest to JSON
            string json = JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true });

            // Write manifest to file
            File.WriteAllText(manifestPath, json);

            Console.WriteLine("Conversion completed. Manifest saved to " + manifestPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}