// Load a template with custom base URL using TemplateLoadOptions to resolve relative links.

using System;
using Aspose.Html;
using Aspose.Html.Loading;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML template file
            string templatePath = "template.html";
            // Path where the merged result will be saved
            string outputPath = "result.html";
            // Sample data for merging (XML format)
            string dataXml = "<root></root>";

            // Load the template document
            HTMLDocument document = new HTMLDocument(templatePath);
            // Prepare the data for merging
            TemplateData data = new TemplateData(dataXml);
            // Configure loading options (e.g., custom base URL can be set here)
            TemplateLoadOptions options = new TemplateLoadOptions();
            // options.BaseUrl = new Uri("https://example.com/"); // Uncomment if BaseUrl property exists

            // Merge the template with data using the specified options
            Converter.ConvertTemplate(document, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}