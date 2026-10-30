// Convert a template that uses conditional attribute binding for readonly fields based on data flags.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with conditional readonly attribute using placeholder
            string htmlTemplate = "<html><body><input type=\"text\" readonly=\"${isReadOnly}\" /></body></html>";
            string outputPath = "output.html";

            // Load the template content
            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Prepare template data (JSON flag)
            Aspose.Html.Converters.TemplateContentOptions contentOptions = new Aspose.Html.Converters.TemplateContentOptions("{\"isReadOnly\": true}", Aspose.Html.Converters.TemplateContent.XML);
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(contentOptions);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, loadOptions);

            // Save the resulting HTML
            resultDocument.Save(outputPath);

            // Verify the readonly attribute presence
            Aspose.Html.HTMLElement inputElement = (Aspose.Html.HTMLElement)resultDocument.GetElementsByTagName("input")[0];
            bool hasReadonly = inputElement.HasAttribute("readonly");
            Console.WriteLine("Readonly attribute present: " + hasReadonly);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}