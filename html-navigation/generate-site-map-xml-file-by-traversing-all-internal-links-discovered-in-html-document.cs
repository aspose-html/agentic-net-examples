// Generate a site map XML file by traversing all internal links discovered in the HTML document.

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body>" +
                                 "<a href=\"page1.html\">Page 1</a>" +
                                 "<a href=\"http://external.com\">External</a>" +
                                 "<a href=\"/page2.html\">Page 2</a>" +
                                 "<a href=\"#section\">Section</a>" +
                                 "</body></html>";

            // Load HTML document from string
            HTMLDocument doc = new HTMLDocument(htmlContent, "about:blank");

            // Evaluate XPath to get all anchor elements with href attribute
            IXPathResult result = doc.Evaluate("//a[@href]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            Node node;
            HashSet<string> links = new HashSet<string>();

            while ((node = result.IterateNext()) != null)
            {
                HTMLAnchorElement anchor = node as HTMLAnchorElement;
                if (anchor != null)
                {
                    string href = anchor.Href;
                    if (!string.IsNullOrEmpty(href) &&
                        !(href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                          href.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                    {
                        links.Add(href);
                    }
                }
            }

            // Generate sitemap.xml
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("sitemap.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                foreach (string loc in links)
                {
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", loc);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement(); // urlset
                writer.WriteEndDocument();
            }

            Console.WriteLine("Sitemap generated: sitemap.xml");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}