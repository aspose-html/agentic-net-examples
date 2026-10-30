// Create a template from a string that includes a meta tag with dynamic description content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML template with a placeholder for description
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"{{description}}\"/></head><body><h1>Hello, World!</h1></body></html>";
            // JSON data to replace the placeholder
            string jsonData = "{\"description\":\"Dynamic description content\"}";
            // Output file path
            string outputPath = "output.html";

            // Load the HTML template from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Prepare template data
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with the provided data
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML
            resultDocument.Save(outputPath);

            // Clean up
            document.Dispose();
            resultDocument.Dispose();

            Console.WriteLine("Template conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}