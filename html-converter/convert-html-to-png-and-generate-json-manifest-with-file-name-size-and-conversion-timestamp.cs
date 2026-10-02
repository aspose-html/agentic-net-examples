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
            // Define HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose!</h1></body></html>";

            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for PNG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Define output PNG path
            string outputPath = "output.png";

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Gather file information
            var fileInfo = new FileInfo(outputPath);

            // Create manifest object
            var manifest = new
            {
                FileName = fileInfo.Name,
                Size = fileInfo.Length,
                Timestamp = DateTime.UtcNow.ToString("o")
            };

            // Serialize manifest to JSON
            string json = JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true });

            // Write manifest to file
            File.WriteAllText("manifest.json", json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}