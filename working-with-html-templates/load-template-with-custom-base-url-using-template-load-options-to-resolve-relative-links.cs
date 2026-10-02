// Load a template with custom base URL using TemplateLoadOptions to resolve relative links.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputPath = "template.html";
            string outputPath = "output.html";

            // Create a minimal template file with a relative link
            string templateContent = @"<!DOCTYPE html>
<html>
<head><title>Sample Template</title></head>
<body>
    <h1>Hello, {{name}}!</h1>
    <img src=""images/pic.png"" alt=""Sample Image"" />
</body>
</html>";
            File.WriteAllText(inputPath, templateContent);

            // Load the template document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (JSON format)
            var data = new Aspose.Html.Converters.TemplateData("{\"name\":\"World\"}");

            // Load options (no BaseUrl property in this version)
            var options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template
            var resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML
            resultDocument.Save(outputPath);

            Console.WriteLine("Template conversion completed successfully.");
            Console.WriteLine("Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}