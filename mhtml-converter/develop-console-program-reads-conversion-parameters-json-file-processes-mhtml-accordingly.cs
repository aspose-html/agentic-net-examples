// Develop a console program that reads conversion parameters from a JSON file and processes MHTML accordingly.

using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            string jsonPath = "params.json";

            if (!File.Exists(jsonPath))
            {
                var defaultParams = new { SourcePath = "sample.html", OutputPath = "output.mhtml" };
                string json = JsonSerializer.Serialize(defaultParams, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonPath, json);
                File.WriteAllText("sample.html", "<!DOCTYPE html><html><body><h1>Hello, MHTML!</h1></body></html>");
                Console.WriteLine($"Created default {jsonPath} and sample.html. Please run the program again.");
                return;
            }

            string jsonContent = File.ReadAllText(jsonPath);
            var parameters = JsonSerializer.Deserialize<ConversionParameters>(jsonContent);
            if (parameters == null || string.IsNullOrEmpty(parameters.SourcePath) || string.IsNullOrEmpty(parameters.OutputPath))
                throw new InvalidOperationException("Invalid conversion parameters in JSON file.");

            var options = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(parameters.SourcePath, options, parameters.OutputPath);
            Console.WriteLine($"Conversion completed. Output saved to: {parameters.OutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private class ConversionParameters
    {
        public string SourcePath { get; set; }
        public string OutputPath { get; set; }
    }
}