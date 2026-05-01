// Perform a one‑line template conversion by calling ConvertTemplate with source path, data, and output path.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace TemplateConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the HTML template file
                string sourcePath = "template.html";

                // Path to the XML/JSON data file
                string templateDataPath = "data.xml";

                // Create TemplateData from the data file
                TemplateData templateData = new TemplateData(templateDataPath);

                // Path where the rendered HTML will be saved
                string resultPath = "output.html";

                // Default options for template loading
                TemplateLoadOptions options = new TemplateLoadOptions();

                // Load the HTML template document with a sandbox configuration
                HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());

                // Perform the conversion and write the result to the output path
                Converter.ConvertTemplate(document, templateData, options, resultPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}