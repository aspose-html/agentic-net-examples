// Develop a console utility that accepts JSON configuration specifying input paths and desired output formats.

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample JSON configuration
            string jsonConfig = @"[
                { ""input"": ""sample.html"", ""format"": ""pdf"" },
                { ""input"": ""sample.html"", ""format"": ""png"" }
            ]";

            // Ensure sample input file exists
            string samplePath = "sample.html";
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Parse configuration
            var configItems = JsonSerializer.Deserialize<List<ConfigItem>>(jsonConfig, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (var item in configItems)
            {
                string inputPath = item.Input;
                string format = item.Format?.Trim().ToLowerInvariant();

                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Input file not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.ChangeExtension(inputPath, format == "png" ? "png" : "pdf");

                switch (format)
                {
                    case "pdf":
                        {
                            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, pdfOptions, outputPath);
                            Console.WriteLine($"Converted to PDF: {outputPath}");
                            break;
                        }
                    case "png":
                        {
                            var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
                            imgOptions.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
                            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, imgOptions, outputPath);
                            Console.WriteLine($"Converted to PNG: {outputPath}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Unsupported format: {format}");
                            break;
                        }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private class ConfigItem
    {
        public string Input { get; set; }
        public string Format { get; set; }
    }
}