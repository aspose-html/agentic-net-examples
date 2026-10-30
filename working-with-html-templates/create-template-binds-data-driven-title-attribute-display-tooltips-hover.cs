// Create a template that binds a data‑driven title attribute to display tooltips on hover.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string templatePath = "template.html";
            string outputPath = "output.html";

            // Create a simple HTML template with a data‑driven title attribute
            string templateContent = "<html><body><h1 title=\"{{title}}\">Hello World</h1></body></html>";
            File.WriteAllText(templatePath, templateContent);

            // Prepare template data (JSON format)
            string jsonData = "{\"title\":\"This is a tooltip\"}";
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options for the template
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template using the provided data
            Aspose.Html.HTMLDocument resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options);

            // Save the resulting HTML document
            resultDoc.Save(outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}