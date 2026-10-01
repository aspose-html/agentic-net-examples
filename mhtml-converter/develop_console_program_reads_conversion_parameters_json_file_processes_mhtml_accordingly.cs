// Develop a console program that reads conversion parameters from a JSON file and processes MHTML accordingly.

using System;
using System.IO;
using System.Text.Json;

namespace AsposeHtmlMhtmlConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string jsonPath = "conversionParams.json";

                if (!File.Exists(jsonPath))
                {
                    var defaultParams = new { SourcePath = "input.html", OutputPath = "output.mhtml" };
                    string defaultJson = JsonSerializer.Serialize(defaultParams, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonPath, defaultJson);

                    // Create a minimal HTML file if it does not exist
                    if (!File.Exists("input.html"))
                    {
                        File.WriteAllText("input.html", "<html><body><h1>Hello World</h1></body></html>");
                    }
                }

                string jsonContent = File.ReadAllText(jsonPath);
                ConversionParams parameters = JsonSerializer.Deserialize<ConversionParams>(jsonContent);

                if (parameters == null || string.IsNullOrWhiteSpace(parameters.SourcePath) || string.IsNullOrWhiteSpace(parameters.OutputPath))
                {
                    throw new InvalidOperationException("Conversion parameters are missing or invalid.");
                }

                // Ensure the source HTML file exists
                if (!File.Exists(parameters.SourcePath))
                {
                    File.WriteAllText(parameters.SourcePath, "<html><body><p>Sample Content</p></body></html>");
                }

                var options = new Aspose.Html.Saving.MHTMLSaveOptions();

                Aspose.Html.Converters.Converter.ConvertHTML(parameters.SourcePath, parameters.SourcePath, options, parameters.OutputPath);

                Console.WriteLine($"MHTML conversion completed. Output saved to: {parameters.OutputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private class ConversionParams
        {
            public string SourcePath { get; set; }
            public string OutputPath { get; set; }
        }
    }
}