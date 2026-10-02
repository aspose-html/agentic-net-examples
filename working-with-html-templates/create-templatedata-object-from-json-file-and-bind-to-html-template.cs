// Create a TemplateData object from a JSON file and bind it to an HTML template.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string jsonPath = "data.json";
            string templatePath = "template.html";
            string outputPath = "output.html";

            // Create sample JSON file if it does not exist
            if (!File.Exists(jsonPath))
            {
                string jsonContent = @"{ ""name"": ""World"" }";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Create sample HTML template file if it does not exist
            if (!File.Exists(templatePath))
            {
                string htmlTemplate = @"<html><body><h1>Hello, {{name}}!</h1></body></html>";
                File.WriteAllText(templatePath, htmlTemplate);
            }

            // Load template data from JSON file
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template with data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting HTML document
            document.Save(outputPath);
            document.Dispose();

            Console.WriteLine("Template conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}