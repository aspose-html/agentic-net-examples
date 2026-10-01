// Convert HTML to PNG by reading ImageSaveOptions from a JSON configuration file and applying them.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
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
            // Define input HTML file and output PNG file
            string htmlPath = "sample.html";
            string outputPath = "output.png";
            string configPath = "config.json";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose!</h1></body></html>");
            }

            // Create a simple JSON config file if it does not exist
            if (!File.Exists(configPath))
            {
                var defaultConfig = new
                {
                    BackgroundColor = "White"
                };
                string defaultJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, defaultJson);
            }

            // Read configuration
            string json = File.ReadAllText(configPath);
            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            // Configure image save options with PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Apply BackgroundColor if specified in config
            if (root.TryGetProperty("BackgroundColor", out JsonElement bgElement))
            {
                string colorName = bgElement.GetString();
                if (!string.IsNullOrEmpty(colorName))
                {
                    options.BackgroundColor = Color.FromName(colorName);
                }
            }

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}