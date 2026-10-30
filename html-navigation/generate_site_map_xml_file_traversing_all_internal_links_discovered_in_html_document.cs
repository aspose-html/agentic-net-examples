// Generate a site map XML file by traversing all internal links discovered in the HTML document.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with internal links
            string htmlContent = @"
                <html>
                    <head><title>Sample Page</title></head>
                    <body>
                        <a href=""page1.html"">Page 1</a>
                        <a href=""/section/page2.html"">Page 2</a>
                        <a href=""https://external.com/page3.html"">External Page</a>
                        <div>
                            <a href=""#anchor"">Anchor Link</a>
                            <a href=""page4.html"">Page 4</a>
                        </div>
                    </body>
                </html>";

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlContent);

            // Collect internal links
            HashSet<string> internalLinks = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            TraverseNodes(document.DocumentElement, internalLinks);

            // Generate sitemap XML
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement urlset = new XElement(ns + "urlset");

            foreach (string link in internalLinks)
            {
                XElement url = new XElement(ns + "url",
                    new XElement(ns + "loc", link));
                urlset.Add(url);
            }

            XDocument sitemap = new XDocument(urlset);
            string outputPath = "sitemap.xml";
            sitemap.Save(outputPath);

            Console.WriteLine($"Sitemap generated successfully at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void TraverseNodes(Node node, HashSet<string> links)
    {
        for (Node current = node; current != null; current = current.NextSibling)
        {
            if (current is Element element)
            {
                if (string.Equals(element.TagName, "a", StringComparison.OrdinalIgnoreCase))
                {
                    string href = element.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href) &&
                        !href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                        !href.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                        !href.StartsWith("#"))
                    {
                        links.Add(href);
                    }
                }

                // Recursively process child nodes
                if (element.FirstChild != null)
                {
                    TraverseNodes(element.FirstChild, links);
                }
            }
        }
    }
}