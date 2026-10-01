// Populate a template with nested JSON objects and display nested property values using dot notation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Create a minimal HTML template if it does not exist
            if (!File.Exists(templatePath))
            {
                string templateContent = "<html><body><h1>{{title}}</h1><p>{{message}}</p></body></html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create a minimal JSON data file if it does not exist
            if (!File.Exists(jsonPath))
            {
                string jsonContent = "{ \"title\": \"Hello World\", \"message\": \"This is a sample message.\" }";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Load template data from JSON file
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Set template loading options (default options are sufficient for this example)
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template into an HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting document to an output file
            document.Save(outputPath);

            Console.WriteLine($"Template conversion completed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}