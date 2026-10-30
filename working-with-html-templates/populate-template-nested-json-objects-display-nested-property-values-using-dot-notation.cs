// Populate a template with nested JSON objects and display nested property values using dot notation.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare JSON data with nested objects
            string jsonContent = @"{
                ""person"": {
                    ""name"": ""John Doe"",
                    ""age"": 30,
                    ""address"": {
                        ""city"": ""New York"",
                        ""zip"": ""10001""
                    }
                }
            }";
            string jsonPath = "data.json";
            File.WriteAllText(jsonPath, jsonContent);

            // Prepare HTML template using dot notation for nested properties
            string templateContent = @"<html>
<body>
    <h1>Hello {{person.name}}!</h1>
    <p>Age: {{person.age}}</p>
    <p>City: {{person.address.city}}</p>
    <p>ZIP: {{person.address.zip}}</p>
</body>
</html>";
            string templatePath = "template.html";
            File.WriteAllText(templatePath, templateContent);

            // Load template options (default)
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Create template data from JSON file
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Convert template to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, loadOptions);

            // Save the resulting HTML
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine("Template conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}