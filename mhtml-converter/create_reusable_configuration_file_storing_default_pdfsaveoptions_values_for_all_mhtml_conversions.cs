// Create a reusable configuration file that stores default PdfSaveOptions values for all MHTML conversions.

using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(baseDir, "pdfsaveoptions.json");
            string inputPath = Path.Combine(baseDir, "sample.mhtml");
            string outputPath = Path.Combine(baseDir, "result.pdf");

            // Ensure configuration file exists
            if (!File.Exists(configPath))
            {
                var defaultConfig = new
                {
                    FormFieldBehaviour = "Flattened",
                    BackgroundColor = "White"
                };
                string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, json);
            }

            // Load configuration
            string configJson = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<PdfSaveOptionsConfig>(configJson);

            // Create PdfSaveOptions and apply configuration
            PdfSaveOptions options = new PdfSaveOptions();

            if (Enum.TryParse<FormFieldBehaviour>(config.FormFieldBehaviour, out var ffBehaviour))
            {
                options.FormFieldBehaviour = ffBehaviour;
            }

            if (!string.IsNullOrEmpty(config.BackgroundColor))
            {
                options.BackgroundColor = Color.FromName(config.BackgroundColor);
            }

            // Ensure sample MHTML file exists
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><h1>Sample MHTML</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Open MHTML stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Convert MHTML to PDF using configured options
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"Conversion completed successfully. PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private class PdfSaveOptionsConfig
    {
        public string FormFieldBehaviour { get; set; }
        public string BackgroundColor { get; set; }
    }
}