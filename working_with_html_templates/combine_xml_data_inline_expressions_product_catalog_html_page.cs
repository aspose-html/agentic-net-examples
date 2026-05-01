// Combine XML data with inline expressions to generate a product catalog HTML page.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Saving;

namespace ProductCatalogGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the HTML template, XML data source, and the output HTML file
                string templatePath = "template.html";
                string xmlDataPath = "catalog.xml";
                string outputPath = "catalog.html";

                // Load XML data for merging
                var data = new TemplateData(xmlDataPath);

                // Load template merging options (default options are sufficient for this example)
                var loadOptions = new TemplateLoadOptions();

                // Merge the XML data with the HTML template and save the result
                Converter.ConvertTemplate(templatePath, data, loadOptions, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}