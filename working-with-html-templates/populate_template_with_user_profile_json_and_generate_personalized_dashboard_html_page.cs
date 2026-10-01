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
            string jsonPath = "data.json";
            string outputPath = "result.html";

            // Create a minimal template file if it does not exist
            if (!File.Exists(templatePath))
            {
                string templateContent = @"<!DOCTYPE html>
<html>
<head><title>{{title}}</title></head>
<body>
<h1>{{title}}</h1>
<p>{{message}}</p>
</body>
</html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create a minimal JSON data file if it does not exist
            if (!File.Exists(jsonPath))
            {
                string jsonContent = @"{
    ""title"": ""Hello, Aspose!"",
    ""message"": ""This is a sample template conversion.""
}";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Load JSON data as a string
            string jsonData = File.ReadAllText(jsonPath);

            // Prepare template data and load options
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to an HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting document
            document.Save(outputPath);

            Console.WriteLine($"Template conversion completed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during template conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}