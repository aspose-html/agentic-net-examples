// Populate a template with hierarchical XML data to produce nested unordered lists in HTML.

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
            // Path to the HTML template file
            string sourcePath = "template.html";
            // Path to the XML data file
            string templateDataPath = "data.xml";
            // Path where the resulting HTML will be saved
            string resultPath = "output.html";

            // Load XML data for the template
            TemplateData templateData = new TemplateData(templateDataPath);

            // Options for template processing (default settings)
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Load the HTML template document
            HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());

            // Merge the template with the XML data and save the output
            Converter.ConvertTemplate(document, templateData, options, resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}