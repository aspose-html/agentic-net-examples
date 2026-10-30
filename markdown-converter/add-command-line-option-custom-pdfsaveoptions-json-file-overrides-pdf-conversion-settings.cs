// Add a command‑line option to specify custom PdfSaveOptions JSON file that overrides default PDF conversion settings.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input and output paths
            string sourcePath = "sample.html";
            string savePath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Initialize PDF save options with defaults
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;
            options.JpegQuality = 90;

            // If a JSON file path is provided, override options
            if (args.Length > 0 && File.Exists(args[0]))
            {
                string json = File.ReadAllText(args[0]);
                PdfOptionsConfig config = JsonSerializer.Deserialize<PdfOptionsConfig>(json);
                if (config != null)
                {
                    if (config.HorizontalResolution.HasValue)
                        options.HorizontalResolution = config.HorizontalResolution.Value;
                    if (config.VerticalResolution.HasValue)
                        options.VerticalResolution = config.VerticalResolution.Value;
                    if (!string.IsNullOrEmpty(config.BackgroundColor))
                    {
                        try
                        {
                            options.BackgroundColor = ColorTranslator.FromHtml(config.BackgroundColor);
                        }
                        catch
                        {
                            // Fallback to named color if HTML translation fails
                            options.BackgroundColor = Color.FromName(config.BackgroundColor);
                        }
                    }
                    if (config.JpegQuality.HasValue)
                        options.JpegQuality = config.JpegQuality.Value;
                }
            }

            // Load the HTML document and convert to PDF
            HTMLDocument document = new HTMLDocument(sourcePath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine($"Conversion completed. PDF saved to '{savePath}'.");
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