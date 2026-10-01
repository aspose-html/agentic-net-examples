// Develop a console utility that accepts JSON configuration specifying input paths and desired output formats.

using System;
using System.IO;
using System.Text.Json;

class Program
{
    class Config
    {
        public string TemplatePath { get; set; }
        public string JsonDataPath { get; set; }
        public string OutputPath { get; set; }
        public string OutputFormat { get; set; }
    }

    static void Main(string[] args)
    {
        try
        {
            string configPath = args.Length > 0 ? args[0] : "config.json";

            if (!File.Exists(configPath))
            {
                // Create sample files
                string sampleTemplate = "<html><body><h1>Hello {{name}}!</h1></body></html>";
                string sampleJson = "{ \"name\": \"World\" }";

                File.WriteAllText("template.html", sampleTemplate);
                File.WriteAllText("data.json", sampleJson);

                var sampleConfig = new Config
                {
                    TemplatePath = "template.html",
                    JsonDataPath = "data.json",
                    OutputPath = "output.html",
                    OutputFormat = "html"
                };
                string sampleConfigJson = JsonSerializer.Serialize(sampleConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, sampleConfigJson);
                Console.WriteLine($"Sample configuration created at '{configPath}'.");
                Console.WriteLine("Run the program again to perform the conversion.");
                return;
            }

            string configContent = File.ReadAllText(configPath);
            Config config = JsonSerializer.Deserialize<Config>(configContent);

            if (config == null)
                throw new InvalidOperationException("Failed to deserialize configuration.");

            string format = config.OutputFormat?.Trim().ToLowerInvariant();

            if (format == "html")
            {
                Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(config.JsonDataPath);
                Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(config.TemplatePath, templateData, loadOptions);
                document.Save(config.OutputPath);
                Console.WriteLine($"HTML document saved to '{config.OutputPath}'.");
            }
            else
            {
                Console.WriteLine($"Output format '{config.OutputFormat}' is not supported in this example.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}