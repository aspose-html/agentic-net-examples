// Create an HTML template dynamically from a string variable containing markup with data‑binding expressions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<html><body><h1>Hello {{name}}!</h1></body></html>";
            string outputPath = "output.html";

            // Load the template from a string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Data for binding
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"name\":\"John Doe\"}");

            // Load options
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template
            Aspose.Html.HTMLDocument result = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting HTML
            result.Save(outputPath);
            Console.WriteLine("Template converted and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}