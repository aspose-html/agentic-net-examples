// Develop a console utility that accepts JSON configuration specifying input paths and desired output formats.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Saving;

class Config
{
    public string TemplatePath { get; set; }
    public string JsonDataPath { get; set; }
    public string OutputPath { get; set; }
    public string OutputFormat { get; set; } // e.g., "html", "pdf", "png", "txt", "md", "mhtml"
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the JSON configuration file as an argument.");
                return;
            }

            // Read and deserialize configuration
            string configContent = File.ReadAllText(args[0]);
            Config config = JsonSerializer.Deserialize<Config>(configContent);

            if (config == null)
            {
                Console.WriteLine("Failed to parse configuration.");
                return;
            }

            // Prepare template loading options
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Create TemplateData from JSON file (rule: convert-template-with-json)
            string jsonPath = config.JsonDataPath;
            TemplateData templateData = new TemplateData(jsonPath);

            // Determine if direct HTML output is required
            if (string.Equals(config.OutputFormat, "html", StringComparison.OrdinalIgnoreCase))
            {
                // Convert template directly to HTML file
                Converter.ConvertTemplate(config.TemplatePath, templateData, loadOptions, config.OutputPath);
                Console.WriteLine($"HTML generated at: {config.OutputPath}");
                return;
            }

            // For other formats, first generate intermediate HTML file
            string intermediateHtml = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");
            Converter.ConvertTemplate(config.TemplatePath, templateData, loadOptions, intermediateHtml);

            // Convert the intermediate HTML to the desired format
            switch (config.OutputFormat.ToLower())
            {
                case "pdf":
                    var pdfOptions = new PdfSaveOptions();
                    Converter.ConvertHTML(intermediateHtml, pdfOptions, config.OutputPath);
                    break;
                case "png":
                case "jpg":
                case "jpeg":
                case "bmp":
                case "gif":
                    var imageOptions = new ImageSaveOptions();
                    Converter.ConvertHTML(intermediateHtml, imageOptions, config.OutputPath);
                    break;
                case "txt":
                    var textOptions = new TextSaveOptions();
                    Converter.ConvertHTML(intermediateHtml, textOptions, config.OutputPath);
                    break;
                case "md":
                case "markdown":
                    var mdOptions = new MarkdownSaveOptions();
                    Converter.ConvertHTML(intermediateHtml, mdOptions, config.OutputPath);
                    break;
                case "mhtml":
                    var mhtmlOptions = new MHTMLSaveOptions();
                    Converter.ConvertHTML(intermediateHtml, mhtmlOptions, config.OutputPath);
                    break;
                default:
                    Console.WriteLine($"Unsupported output format: {config.OutputFormat}");
                    break;
            }

            // Clean up temporary HTML file
            if (File.Exists(intermediateHtml))
            {
                File.Delete(intermediateHtml);
            }

            Console.WriteLine($"Conversion completed. Output at: {config.OutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}