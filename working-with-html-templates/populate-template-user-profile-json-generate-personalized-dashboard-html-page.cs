// Populate a template with user profile JSON and generate a personalized dashboard HTML page.

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
            string jsonPath = "profile.json";
            string outputPath = "dashboard.html";

            // Create a minimal template file if it does not exist
            if (!File.Exists(templatePath))
            {
                string templateContent = "<html><body><h1>Welcome, {{name}}!</h1><p>Age: {{age}}</p></body></html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create a minimal JSON data file if it does not exist
            if (!File.Exists(jsonPath))
            {
                string jsonContent = "{\"name\":\"John Doe\",\"age\":30}";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Load template data from JSON file
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load options for template processing
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with the data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, loadOptions);

            // Save the resulting HTML document
            document.Save(outputPath);

            Console.WriteLine("Dashboard generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}