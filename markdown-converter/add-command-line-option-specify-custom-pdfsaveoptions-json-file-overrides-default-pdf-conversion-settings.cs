// Add a command‑line option to specify custom PdfSaveOptions JSON file that overrides default PDF conversion settings.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    class PdfOptionsConfig
    {
        public int? HorizontalResolution { get; set; }
        public int? VerticalResolution { get; set; }
        public string BackgroundColor { get; set; }
        public int? JpegQuality { get; set; }
    }

    static void Main(string[] args)
    {
        try
        {
            // Default input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Ensure sample HTML file exists
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Create default PDF save options
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.White;
            options.JpegQuality = 90;

            // If a JSON file path is provided as the first command‑line argument, load overrides
            if (args.Length > 0)
            {
                string jsonPath = args[0];
                if (File.Exists(jsonPath))
                {
                    string jsonContent = File.ReadAllText(jsonPath);
                    PdfOptionsConfig config = JsonSerializer.Deserialize<PdfOptionsConfig>(jsonContent);
                    if (config != null)
                    {
                        if (config.HorizontalResolution.HasValue)
                            options.HorizontalResolution = config.HorizontalResolution.Value;
                        if (config.VerticalResolution.HasValue)
                            options.VerticalResolution = config.VerticalResolution.Value;
                        if (!string.IsNullOrEmpty(config.BackgroundColor))
                            options.BackgroundColor = Color.FromName(config.BackgroundColor);
                        if (config.JpegQuality.HasValue)
                            options.JpegQuality = config.JpegQuality.Value;
                    }
                }
                else
                {
                    Console.WriteLine($"JSON configuration file not found: {jsonPath}");
                }
            }

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to PDF with the configured options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine($"Conversion completed. PDF saved to: {pdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}