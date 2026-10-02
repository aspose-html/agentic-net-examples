// Populate a template with nested JSON objects and display nested property values using dot notation.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define file paths
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Create sample template file
            if (!File.Exists(templatePath))
            {
                string templateContent = @"<html><body>
<h1>Hello {{person.name}}!</h1>
<p>Age: {{person.age}}</p>
<p>City: {{person.address.city}}</p>
</body></html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create sample JSON data file
            if (!File.Exists(jsonPath))
            {
                string jsonContent = @"{
  ""person"": {
    ""name"": ""John Doe"",
    ""age"": 30,
    ""address"": {
      ""city"": ""New York""
    }
  }
}";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Load template data
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template with data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options);

            // Save the resulting HTML
            document.Save(outputPath);

            Console.WriteLine("Template conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}