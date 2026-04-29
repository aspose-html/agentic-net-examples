// Add a command‑line option to specify custom PdfSaveOptions JSON file that overrides default PDF conversion settings.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
                throw new ArgumentException("Usage: <inputHtmlPath> <outputPdfPath> [optionsJsonPath]");

            string inputHtmlPath = args[0];
            string outputPdfPath = args[1];
            string optionsJsonPath = args.Length >= 3 ? args[2] : null;

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            if (!string.IsNullOrEmpty(optionsJsonPath) && File.Exists(optionsJsonPath))
            {
                string json = File.ReadAllText(optionsJsonPath);
                var config = JsonSerializer.Deserialize<PdfOptionsConfig>(json);
                if (config != null)
                {
                    if (config.HorizontalResolution.HasValue)
                        options.HorizontalResolution = config.HorizontalResolution.Value;
                    if (config.VerticalResolution.HasValue)
                        options.VerticalResolution = config.VerticalResolution.Value;
                    if (!string.IsNullOrEmpty(config.BackgroundColor))
                        options.BackgroundColor = ColorTranslator.FromHtml(config.BackgroundColor);
                    if (config.JpegQuality.HasValue)
                        options.JpegQuality = config.JpegQuality.Value;
                }
            }

            Converter.ConvertHTML(inputHtmlPath, options, outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
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