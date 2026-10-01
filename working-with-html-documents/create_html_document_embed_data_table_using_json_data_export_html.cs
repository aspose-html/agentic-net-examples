// Create an HTML document, embed a data table using JSON data, and export to HTML.

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
                string templateContent = @"<html>
    <body>
        <h1>{{title}}</h1>
        <p>{{description}}</p>
    </body>
</html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create a minimal JSON data file if it does not exist
            if (!File.Exists(jsonPath))
            {
                string jsonContent = @"{
    ""title"": ""Hello World"",
    ""description"": ""This is a sample description.""
}";
                File.WriteAllText(jsonPath, jsonContent);
            }

            // Load template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load options for template processing
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with the provided data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(
                templatePath,
                templateData,
                loadOptions);

            // Save the resulting HTML document
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