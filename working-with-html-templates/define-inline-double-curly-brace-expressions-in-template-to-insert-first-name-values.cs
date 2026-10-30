// Define inline double‑curly‑brace expressions in the template to insert first name values.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "template.html";
            string outputPath = "output.html";

            // Create a simple HTML template with a double-curly-brace placeholder
            string templateContent = @"<!DOCTYPE html>
<html>
<head><title>Greeting</title></head>
<body>
<p>Hello, {{FirstName}}!</p>
</body>
</html>";
            File.WriteAllText(inputPath, templateContent);

            // JSON data to replace the placeholder
            string jsonData = @"{ ""FirstName"": ""John"" }";

            // Load the HTML template document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data and load options
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Perform template conversion
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML
            resultDocument.Save(outputPath);

            Console.WriteLine($"Template conversion completed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}