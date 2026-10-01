// Run batch validation on all HTML files in a project folder and produce a consolidated JSON report.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string inputFolder = "Input";
            string outputFolder = "Output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Define file paths
            string templatePath = Path.Combine(inputFolder, "template.html");
            string jsonPath = Path.Combine(inputFolder, "data.json");
            string outputPath = Path.Combine(outputFolder, "result.html");

            // Create a minimal template if it does not exist
            if (!File.Exists(templatePath))
            {
                File.WriteAllText(templatePath,
                    "<html><body><h1>{{title}}</h1><p>{{description}}</p></body></html>");
            }

            // Create a minimal JSON data file if it does not exist
            if (!File.Exists(jsonPath))
            {
                File.WriteAllText(jsonPath,
                    "{ \"title\": \"Hello World\", \"description\": \"Sample description\" }");
            }

            // Load template data
            Aspose.Html.Converters.TemplateData templateData =
                new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load options for the template
            Aspose.Html.Loading.TemplateLoadOptions loadOptions =
                new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to an HTML document
            Aspose.Html.HTMLDocument resultDocument =
                Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting HTML
            resultDocument.Save(outputPath);

            Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}