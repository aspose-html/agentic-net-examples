// Add a command‑line option to specify custom PdfSaveOptions JSON file that overrides default PDF conversion settings.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input and output paths
            string sourcePath = "sample.md";
            string savePath = "output.pdf";

            // Ensure sample markdown file exists
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a **test** document.");
            }

            // Create default PDF save options
            PdfSaveOptions options = new PdfSaveOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                JpegQuality = 90
            };

            // If a JSON configuration file is provided, override defaults
            if (args.Length > 0)
            {
                string jsonPath = args[0];
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    var config = JsonSerializer.Deserialize<PdfOptionsConfig>(json);
                    if (config != null)
                    {
                        if (config.HorizontalResolution.HasValue)
                            options.HorizontalResolution = config.HorizontalResolution.Value;
                        if (config.VerticalResolution.HasValue)
                            options.VerticalResolution = config.VerticalResolution.Value;
                        if (!string.IsNullOrEmpty(config.BackgroundColor))
                        {
                            // Try to parse known color name; fallback to White if unknown
                            Color parsed = Color.FromName(config.BackgroundColor);
                            if (parsed.IsKnownColor)
                                options.BackgroundColor = parsed;
                        }
                        if (config.JpegQuality.HasValue)
                            options.JpegQuality = config.JpegQuality.Value;
                    }
                }
                else
                {
                    Console.WriteLine($"Configuration file not found: {jsonPath}");
                }
            }

            // Convert markdown to HTML document
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Convert HTML document to PDF using the options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine($"Conversion completed. PDF saved to: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private class PdfOptionsConfig
    {
        public int? HorizontalResolution { get; set; }
        public int? VerticalResolution { get; set; }
        public string BackgroundColor { get; set; }
        public int? JpegQuality { get; set; }
    }
}