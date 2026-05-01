// Set the checked attribute on a checkbox conditionally based on a boolean value in the data source.

using System;
using Aspose.Html;
using Aspose.Html.Loading;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML template file
            string htmlTemplate = "template.html";

            // Boolean value determining the checked state
            bool isChecked = true;

            // Path for the generated output HTML file
            string outputPath = "output.html";

            // Load the template document (base URL is empty)
            HTMLDocument templateDocument = new HTMLDocument(htmlTemplate, string.Empty);

            // XML data for template merging (can be empty if not used)
            string xmlData = "<root></root>";
            TemplateContentOptions contentOptions = new TemplateContentOptions(xmlData, TemplateContent.XML);
            TemplateData templateData = new TemplateData(contentOptions);

            // Load options for template conversion
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Merge template with data and save to outputPath
            Converter.ConvertTemplate(templateDocument, templateData, loadOptions, outputPath);

            // Load the resulting document
            HTMLDocument resultDocument = new HTMLDocument(outputPath);

            // Get the first input element (checkbox) and set its checked state
            HTMLInputElement input = (HTMLInputElement)resultDocument.GetElementsByTagName("input")[0];
            input.Checked = isChecked;

            // Save the modified document
            resultDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}