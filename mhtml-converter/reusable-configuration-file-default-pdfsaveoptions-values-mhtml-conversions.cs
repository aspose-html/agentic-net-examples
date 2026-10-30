// Create a reusable configuration file that stores default PdfSaveOptions values for all MHTML conversions.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the reusable configuration file
            string configPath = "pdfOptionsConfig.json";

            // Create default configuration if it does not exist
            if (!File.Exists(configPath))
            {
                var defaultConfig = new PdfOptionsConfig
                {
                    FormFieldBehaviour = "Flattened"
                };
                string defaultJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, defaultJson);
            }

            // Load configuration
            string configJson = File.ReadAllText(configPath);
            PdfOptionsConfig config = JsonSerializer.Deserialize<PdfOptionsConfig>(configJson);

            // Prepare PdfSaveOptions using values from configuration
            var pdfOptions = new PdfSaveOptions();
            if (config != null && !string.IsNullOrEmpty(config.FormFieldBehaviour))
            {
                if (Enum.TryParse<FormFieldBehaviour>(config.FormFieldBehaviour, out var behaviour))
                {
                    pdfOptions.FormFieldBehaviour = behaviour;
                }
            }

            // Ensure a sample MHTML source file exists
            string sourcePath = "sample.mhtml";
            if (!File.Exists(sourcePath))
            {
                // Minimal MHTML content (plain HTML saved with .mhtml extension)
                File.WriteAllText(sourcePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            // Define output PDF path
            string outputPath = "output.pdf";

            // Convert MHTML to PDF using the configured options
            using (Stream stream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("MHTML conversion to PDF completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Configuration class matching the JSON structure
class PdfOptionsConfig
{
    public string FormFieldBehaviour { get; set; }
}