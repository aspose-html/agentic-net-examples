// Generate a sitemap XML file alongside the HTML output to map converted pages.

using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the template, data and output HTML
            string sourcePath = "template.html";
            string templateDataPath = "data.xml";
            string resultPath = "output.html";

            // Create TemplateData from the XML file
            TemplateData templateData = new TemplateData(templateDataPath);

            // Load options for template processing
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Load the HTML template into a document
            HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());

            // Convert the template with data and save the result HTML
            Converter.ConvertTemplate(document, templateData, loadOptions, resultPath);

            // Release resources
            document.Dispose();

            // Generate a simple sitemap XML referencing the generated HTML page
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement urlElement = new XElement(ns + "url",
                new XElement(ns + "loc", new Uri(Path.GetFullPath(resultPath)).AbsoluteUri));
            XDocument sitemap = new XDocument(
                new XElement(ns + "urlset", urlElement)
            );

            // Save the sitemap alongside the HTML output
            string sitemapPath = "sitemap.xml";
            sitemap.Save(sitemapPath);

            Console.WriteLine("Conversion and sitemap generation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}