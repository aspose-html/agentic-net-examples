// Convert HTML to PNG and generate a JSON manifest containing file name, size, and conversion timestamp.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string htmlContent = "<html><body><h1>Hello, Aspose!</h1></body></html>";

            // Base URI for the HTML (current directory)
            string baseUri = Directory.GetCurrentDirectory();

            // Output PNG file path
            string outputPath = Path.Combine(baseUri, "output.png");

            // Image save options (default PNG format)
            ImageSaveOptions options = new ImageSaveOptions();

            // Convert HTML string to PNG image
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            // Gather file information for the manifest
            FileInfo fileInfo = new FileInfo(outputPath);
            var manifest = new
            {
                FileName = fileInfo.Name,
                Size = fileInfo.Length,
                Timestamp = fileInfo.LastWriteTimeUtc
            };

            // Serialize manifest to JSON
            string json = JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON manifest to file
            string manifestPath = Path.Combine(baseUri, "manifest.json");
            File.WriteAllText(manifestPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}