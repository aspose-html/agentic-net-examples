// Apply TemplateLoadOptions to enable loading HTML templates that contain external CSS references for styling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string cssPath = "styles.css";
            string outputPath = "output.html";

            // Create a minimal external CSS file
            System.IO.File.WriteAllText(cssPath, "body { background-color: #e5f3fd; }");

            // Create a simple HTML template that references the external CSS
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><p>Hello, {{name}}!</p></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            // Load the template
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (JSON format)
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"name\":\"World\"}");

            // Enable loading options for external resources
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with data and options
            Aspose.Html.HTMLDocument result = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML
            result.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}