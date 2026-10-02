// Generate a sitemap XML file alongside the HTML output to map converted pages.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare paths
            string sourcePath = "sample.html";
            string outputDir = "output";
            string resultPath = Path.Combine(outputDir, "sample_converted.html");
            string sitemapPath = Path.Combine(outputDir, "sitemap.xml");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Save the converted HTML to the result path
            document.Save(resultPath);
            document.Dispose();

            // Generate a simple sitemap XML file
            string sitemapXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">
  <url>
    <loc>" + resultPath.Replace("\\", "/") + @"</loc>
  </url>
</urlset>";
            File.WriteAllText(sitemapPath, sitemapXml);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("HTML output: " + resultPath);
            Console.WriteLine("Sitemap generated: " + sitemapPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}