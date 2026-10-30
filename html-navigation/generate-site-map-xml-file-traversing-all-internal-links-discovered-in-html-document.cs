// Generate a site map XML file by traversing all internal links discovered in the HTML document.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with internal and external links
            string htmlContent = @"
                <html>
                    <head><title>Sample Page</title></head>
                    <body>
                        <a href=""#section1"">Section 1</a>
                        <a href=""/about.html"">About</a>
                        <a href=""https://example.com/contact"">Contact (external)</a>
                        <a href=""page2.html"">Page 2</a>
                        <a href=""#section2"">Section 2</a>
                    </body>
                </html>";

            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // XPath to select all anchor elements with href attribute
            IXPathResult result = document.Evaluate(
                "//a[@href]",
                document,
                document.CreateNSResolver(document),
                XPathResultType.Any,
                null);

            var internalLinks = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                var anchor = (Aspose.Html.HTMLAnchorElement)node;
                string href = anchor.Href;

                if (string.IsNullOrEmpty(href))
                    continue;

                // Determine if the link is internal (relative or fragment)
                bool isExternal = href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                                  href.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
                if (!isExternal)
                {
                    internalLinks.Add(href);
                }
            }

            // Build sitemap XML
            var sb = new StringBuilder();
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            sb.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");
            foreach (var link in internalLinks)
            {
                // Resolve relative URLs against a base (using the base URI of the document)
                string absoluteUrl = new Uri(new Uri("https://example.com/"), link).AbsoluteUri;
                sb.AppendLine("  <url>");
                sb.AppendLine($"    <loc>{System.Security.SecurityElement.Escape(absoluteUrl)}</loc>");
                sb.AppendLine("  </url>");
            }
            sb.AppendLine(@"</urlset>");

            // Write sitemap to file
            string outputPath = "sitemap.xml";
            File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
            Console.WriteLine($"Sitemap generated at: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}