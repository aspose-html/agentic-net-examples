// Populate a template with user profile JSON and generate a personalized dashboard HTML page.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML template with placeholders
            string templatePath = "template.html";
            string templateContent = "<html><body><h1>Welcome, {{name}}!</h1><p>Age: {{age}}</p></body></html>";
            File.WriteAllText(templatePath, templateContent);

            // Create a JSON file with user profile data
            string jsonPath = "profile.json";
            string jsonContent = "{ \"name\": \"John Doe\", \"age\": 30 }";
            File.WriteAllText(jsonPath, jsonContent);

            // Load template data from JSON
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load options for the template
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template using the data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the personalized dashboard HTML
            string outputPath = "dashboard.html";
            document.Save(outputPath);

            Console.WriteLine($"Dashboard generated at: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}