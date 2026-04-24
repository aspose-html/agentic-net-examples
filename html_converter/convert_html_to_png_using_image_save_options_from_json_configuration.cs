// Convert HTML to PNG by reading ImageSaveOptions from a JSON configuration file and applying them.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPngWithConfig
{
    class Program
    {
        // Configuration class matching JSON structure for ImageSaveOptions
        private class ImageSaveOptionsConfig
        {
            public bool? UseAntialiasing { get; set; }
            public int? HorizontalResolution { get; set; }
            public int? VerticalResolution { get; set; }
            public string BackgroundColor { get; set; }
        }

        static void Main(string[] args)
        {
            try
            {
                // Expect three arguments: input HTML file, output PNG file, JSON config file
                if (args.Length != 3)
                {
                    Console.WriteLine("Usage: HtmlToPngWithConfig <input.html> <output.png> <options.json>");
                    return;
                }

                string htmlPath = args[0];
                string outputPath = args[1];
                string jsonConfigPath = args[2];

                // Load HTML content
                string htmlContent = File.ReadAllText(htmlPath);
                // Determine base URI for relative resources
                string baseUri = Path.GetDirectoryName(Path.GetFullPath(htmlPath)) ?? "";

                // Load JSON configuration
                ImageSaveOptionsConfig config = JsonSerializer.Deserialize<ImageSaveOptionsConfig>(File.ReadAllText(jsonConfigPath));

                // Create ImageSaveOptions instance
                ImageSaveOptions options = new ImageSaveOptions();

                // Apply configuration values if they are present
                if (config != null)
                {
                    if (config.UseAntialiasing.HasValue)
                        options.UseAntialiasing = config.UseAntialiasing.Value;

                    if (config.HorizontalResolution.HasValue)
                        options.HorizontalResolution = config.HorizontalResolution.Value;

                    if (config.VerticalResolution.HasValue)
                        options.VerticalResolution = config.VerticalResolution.Value;

                    if (!string.IsNullOrWhiteSpace(config.BackgroundColor))
                        options.BackgroundColor = ColorTranslator.FromHtml(config.BackgroundColor);
                }

                // Convert HTML to PNG using Aspose.Html
                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

                Console.WriteLine($"Conversion completed. PNG saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}