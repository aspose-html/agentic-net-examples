// Create an HTML template dynamically from a string variable containing markup with data‑binding expressions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // HTML template with data‑binding expressions
            string htmlTemplate = "<!DOCTYPE html><html><head><title>Template</title></head><body><h1>Hello {{name}}!</h1></body></html>";

            // JSON data for the template
            string jsonData = "{\"name\":\"World\"}";

            // Load the template from the string (use a dummy base URI)
            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Prepare template data
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Perform template conversion
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, data, options);

            // Save the resulting HTML
            string outputPath = "output.html";
            resultDocument.Save(outputPath);
            Console.WriteLine($"Template processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}