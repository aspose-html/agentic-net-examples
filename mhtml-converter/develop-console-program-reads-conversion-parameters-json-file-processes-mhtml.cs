// Develop a console program that reads conversion parameters from a JSON file and processes MHTML accordingly.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    class ConversionParams
    {
        public string SourcePath { get; set; }
        public string OutputPath { get; set; }
    }

    static void Main(string[] args)
    {
        try
        {
            // Define default file paths
            string jsonPath = "conversion_params.json";
            string defaultHtmlPath = "sample.html";
            string defaultMhtmlPath = "output.mhtml";

            // Ensure sample JSON exists
            if (!File.Exists(jsonPath))
            {
                var defaultParams = new ConversionParams
                {
                    SourcePath = defaultHtmlPath,
                    OutputPath = defaultMhtmlPath
                };
                string jsonContent = JsonSerializer.Serialize(defaultParams, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Ensure sample HTML exists
            if (!File.Exists(defaultHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(defaultHtmlPath, sampleHtml);
            }

            // Read conversion parameters from JSON
            string jsonText = File.ReadAllText(jsonPath);
            ConversionParams parameters = JsonSerializer.Deserialize<ConversionParams>(jsonText);

            if (parameters == null || string.IsNullOrEmpty(parameters.SourcePath) || string.IsNullOrEmpty(parameters.OutputPath))
                throw new InvalidOperationException("Invalid conversion parameters.");

            // Prepare MHTML save options
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(parameters.SourcePath, parameters.SourcePath, options, parameters.OutputPath);

            Console.WriteLine($"MHTML file generated at: {Path.GetFullPath(parameters.OutputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}