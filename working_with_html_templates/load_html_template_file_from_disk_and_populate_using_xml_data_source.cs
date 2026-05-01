// Load an HTML template file from disk and populate it using an XML data source.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace TemplatePopulationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the template HTML, XML data source and the output file
                string templatePath = "template.html";
                string dataPath = "data.xml";
                string outputPath = "output.html";

                // Load XML data that will be merged into the template
                TemplateData templateData = new TemplateData(dataPath);

                // Options for template loading (default settings)
                TemplateLoadOptions options = new TemplateLoadOptions();

                // Load the HTML template document with a sandbox configuration
                HTMLDocument document = new HTMLDocument(templatePath, new Configuration());

                // Perform the template conversion, merging data and saving the result
                Converter.ConvertTemplate(document, templateData, options, outputPath);

                // Release resources
                document.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}