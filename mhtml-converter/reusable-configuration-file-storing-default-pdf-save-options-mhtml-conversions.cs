// Create a reusable configuration file that stores default PdfSaveOptions values for all MHTML conversions.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

namespace AsposeHtmlMhtmlToPdf
{
    class PdfOptionsConfig
    {
        public string FormFieldBehaviour { get; set; }

        public static PdfSaveOptions Load(string configPath)
        {
            if (!File.Exists(configPath))
            {
                // Create default configuration file
                var defaultConfig = new PdfOptionsConfig { FormFieldBehaviour = "Flattened" };
                string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, json);
                return CreateOptions(defaultConfig);
            }

            string content = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<PdfOptionsConfig>(content);
            return CreateOptions(config);
        }

        private static PdfSaveOptions CreateOptions(PdfOptionsConfig config)
        {
            var options = new PdfSaveOptions();

            if (Enum.TryParse<FormFieldBehaviour>(config.FormFieldBehaviour, out var behaviour))
            {
                options.FormFieldBehaviour = behaviour;
            }

            return options;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Paths
                string configPath = "pdfOptionsConfig.json";
                string sourcePath = "sample.mhtml";
                string outputPath = "output.pdf";

                // Ensure sample MHTML file exists
                if (!File.Exists(sourcePath))
                {
                    string sampleHtml = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                    File.WriteAllText(sourcePath, sampleHtml);
                }

                // Load PDF save options from configuration
                PdfSaveOptions pdfOptions = PdfOptionsConfig.Load(configPath);

                // Open MHTML file stream
                using (Stream stream = File.OpenRead(sourcePath))
                {
                    // Convert MHTML to PDF using loaded options
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }

                Console.WriteLine($"Conversion completed successfully. PDF saved to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}