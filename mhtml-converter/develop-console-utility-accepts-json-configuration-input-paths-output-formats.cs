// Develop a console utility that accepts JSON configuration specifying input paths and desired output formats.

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    class Config
    {
        public string InputPath { get; set; }
        public string[] OutputFormats { get; set; }
    }

    static void Main(string[] args)
    {
        try
        {
            string configPath = "config.json";
            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
                configPath = args[0];

            if (!File.Exists(configPath))
            {
                // Create sample HTML input
                string sampleHtmlPath = "sample.html";
                if (!File.Exists(sampleHtmlPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    File.WriteAllText(sampleHtmlPath, sampleHtml);
                }

                // Create sample config
                var sampleConfig = new Config
                {
                    InputPath = sampleHtmlPath,
                    OutputFormats = new[] { "pdf", "png", "docx", "txt", "markdown" }
                };
                string json = JsonSerializer.Serialize(sampleConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, json);
                Console.WriteLine($"Sample config created at '{configPath}'. Edit it as needed and rerun the program.");
                return;
            }

            string configJson = File.ReadAllText(configPath);
            Config config = JsonSerializer.Deserialize<Config>(configJson);
            if (config == null || string.IsNullOrWhiteSpace(config.InputPath) || config.OutputFormats == null)
                throw new InvalidOperationException("Invalid configuration.");

            if (!File.Exists(config.InputPath))
                throw new FileNotFoundException($"Input file not found: {config.InputPath}");

            foreach (string format in config.OutputFormats)
            {
                string fmt = format.Trim().ToLowerInvariant();
                string outputPath = Path.ChangeExtension(config.InputPath, GetExtension(fmt));

                switch (fmt)
                {
                    case "pdf":
                        {
                            var options = new Aspose.Html.Saving.PdfSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertHTML(config.InputPath, options, outputPath);
                            Console.WriteLine($"PDF saved to: {outputPath}");
                            break;
                        }
                    case "png":
                    case "jpeg":
                    case "jpg":
                    case "bmp":
                    case "gif":
                    case "tiff":
                        {
                            var options = new Aspose.Html.Saving.ImageSaveOptions();
                            if (fmt == "png")
                                options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
                            else if (fmt == "jpeg" || fmt == "jpg")
                                options.Format = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
                            else if (fmt == "bmp")
                                options.Format = Aspose.Html.Rendering.Image.ImageFormat.Bmp;
                            else if (fmt == "gif")
                                options.Format = Aspose.Html.Rendering.Image.ImageFormat.Gif;
                            else if (fmt == "tiff")
                                options.Format = Aspose.Html.Rendering.Image.ImageFormat.Tiff;
                            Aspose.Html.Converters.Converter.ConvertHTML(config.InputPath, options, outputPath);
                            Console.WriteLine($"Image saved to: {outputPath}");
                            break;
                        }
                    case "docx":
                        {
                            var options = new Aspose.Html.Saving.DocSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertHTML(config.InputPath, options, outputPath);
                            Console.WriteLine($"DOCX saved to: {outputPath}");
                            break;
                        }
                    case "txt":
                        {
                            var options = new Aspose.Html.Saving.TextSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertHTML(config.InputPath, options, outputPath);
                            Console.WriteLine($"Text saved to: {outputPath}");
                            break;
                        }
                    case "markdown":
                    case "md":
                        {
                            var options = new Aspose.Html.Saving.MarkdownSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertHTML(config.InputPath, options, outputPath);
                            Console.WriteLine($"Markdown saved to: {outputPath}");
                            break;
                        }
                    default:
                        Console.WriteLine($"Unsupported format: {format}");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string GetExtension(string format)
    {
        return format switch
        {
            "pdf" => ".pdf",
            "png" => ".png",
            "jpeg" => ".jpeg",
            "jpg" => ".jpg",
            "bmp" => ".bmp",
            "gif" => ".gif",
            "tiff" => ".tiff",
            "docx" => ".docx",
            "txt" => ".txt",
            "markdown" => ".md",
            "md" => ".md",
            _ => ".out"
        };
    }
}