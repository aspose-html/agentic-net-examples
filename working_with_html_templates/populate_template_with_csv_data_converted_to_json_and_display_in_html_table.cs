// Populate a template with CSV data converted to JSON and display it in an HTML table.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace AsposeHtmlTemplateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define file paths
                string csvPath = "data.csv";
                string jsonPath = "data.json";
                string templatePath = "template.html";
                string outputPath = "output.html";

                // Convert CSV to JSON and save to file
                string jsonContent = ConvertCsvToJson(csvPath);
                File.WriteAllText(jsonPath, jsonContent, Encoding.UTF8);

                // Prepare template data and load options
                TemplateData templateData = new TemplateData(jsonPath);
                TemplateLoadOptions loadOptions = new TemplateLoadOptions();

                // Merge template with JSON data and generate final HTML
                Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);

                Console.WriteLine($"Template populated successfully. Output saved to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Reads a CSV file and converts its content to a JSON array string
        private static string ConvertCsvToJson(string csvFilePath)
        {
            var lines = File.ReadAllLines(csvFilePath);
            if (lines.Length < 2)
                throw new InvalidOperationException("CSV file must contain header and at least one data row.");

            var headers = lines[0].Split(',');

            var records = new List<Dictionary<string, string>>();
            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var record = new Dictionary<string, string>();
                for (int j = 0; j < headers.Length && j < values.Length; j++)
                {
                    record[headers[j].Trim()] = values[j].Trim();
                }
                records.Add(record);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(records, options);
        }
    }
}