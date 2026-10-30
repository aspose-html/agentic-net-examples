// Generate a sitemap XML file alongside the HTML output to map converted pages.

using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "input.html";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "page.html");
            string sitemapPath = Path.Combine(outputDir, "sitemap.xml");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Save the document to the output path
            document.Save(outputPath);
            document.Dispose();

            // Generate a simple sitemap XML file
            using (XmlWriter writer = XmlWriter.Create(sitemapPath, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                writer.WriteStartElement("url");
                // Use file URI for the location
                string fileUri = new Uri(Path.GetFullPath(outputPath)).AbsoluteUri;
                writer.WriteElementString("loc", fileUri);
                writer.WriteEndElement(); // </url>

                writer.WriteEndElement(); // </urlset>
                writer.WriteEndDocument();
            }

            Console.WriteLine("HTML conversion and sitemap generation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}