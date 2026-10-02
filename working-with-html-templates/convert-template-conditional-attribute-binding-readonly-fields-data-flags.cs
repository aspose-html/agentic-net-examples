// Convert a template that uses conditional attribute binding for readonly fields based on data flags.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with conditional readonly attribute
            string htmlTemplate = "<!DOCTYPE html><html><body>" +
                                  "<input type=\"text\" {% if isReadOnly %}readonly=\"readonly\"{% endif %} />" +
                                  "</body></html>";

            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Create HTMLDocument from inline template content
            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Template data (JSON) indicating the readonly flag
            string jsonData = "{\"isReadOnly\": true}";
            Aspose.Html.Converters.TemplateContentOptions contentOptions = new Aspose.Html.Converters.TemplateContentOptions(jsonData, Aspose.Html.Converters.TemplateContent.JSON);
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(contentOptions);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template with data
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, loadOptions);

            // Save the resulting HTML
            resultDocument.Save(outputPath);

            // Verify the readonly attribute
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)resultDocument.GetElementsByTagName("input")[0];
            bool hasReadonly = input.HasAttribute("readonly");
            Console.WriteLine("Readonly attribute present: " + hasReadonly);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}