// Use a single line of code to convert a template string directly to an HTML file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a placeholder for template data
            string htmlContent = "<html><body><p>Hello {{name}}</p></body></html>";

            // Sample JSON data to fill the template
            string jsonData = "{\"name\":\"World\"}";

            // Output file path
            string outputPath = Path.Combine(Path.GetTempPath(), "template_result.html");

            // Create an HTMLDocument from the HTML string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Create TemplateData from the JSON string
            var templateData = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options for the template conversion
            var loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Perform the template conversion; it returns a new HTMLDocument
            var resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, loadOptions);

            // Save the resulting document to the output file
            resultDocument.Save(outputPath);

            // Clean up resources
            resultDocument.Dispose();
            document.Dispose();

            Console.WriteLine($"Template conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}