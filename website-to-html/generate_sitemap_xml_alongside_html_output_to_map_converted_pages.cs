// Generate a sitemap XML file alongside the HTML output to map converted pages.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string sourcePath = "template.html";
            string templateDataPath = "data.xml";
            string resultPath = "output.html";
            string sitemapPath = "sitemap.xml";

            // Create minimal sample files if they do not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><h1>{{title}}</h1></body></html>");
            }

            if (!File.Exists(templateDataPath))
            {
                File.WriteAllText(templateDataPath, "<data><title>Sample Title</title></data>");
            }

            // Prepare template data and load options
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Load the HTML template document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Convert the template (returns a new HTMLDocument)
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, loadOptions);

            // Save the resulting HTML
            resultDocument.Save(resultPath);

            // Dispose documents
            resultDocument.Dispose();
            document.Dispose();

            // Generate a simple sitemap XML referencing the output HTML
            string sitemapContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">
  <url>
    <loc>" + resultPath + @"</loc>
    <lastmod>" + DateTime.UtcNow.ToString("yyyy-MM-dd") + @"</lastmod>
    <changefreq>daily</changefreq>
    <priority>0.8</priority>
  </url>
</urlset>";
            File.WriteAllText(sitemapPath, sitemapContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}