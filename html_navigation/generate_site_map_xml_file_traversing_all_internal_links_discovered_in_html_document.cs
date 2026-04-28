// Generate a site map XML file by traversing all internal links discovered in the HTML document.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file or URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("input.html");

            // Collect internal links
            var links = document.Links;
            var sb = new StringBuilder();
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            sb.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");

            foreach (Aspose.Html.Dom.Element link in links)
            {
                string href = link.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Simple filter: treat relative URLs and same-host URLs as internal
                if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    // Optional: compare host with base document host if needed
                    // Skipping external links
                    continue;
                }

                // Resolve relative URLs against the base address
                string fullUrl = new Uri(new Uri("file://" + Path.GetFullPath("input.html")), href).AbsoluteUri;

                sb.AppendLine("  <url>");
                sb.AppendLine($"    <loc>{System.Security.SecurityElement.Escape(fullUrl)}</loc>");
                sb.AppendLine("  </url>");
            }

            sb.AppendLine("</urlset>");

            // Save the sitemap XML
            File.WriteAllText("sitemap.xml", sb.ToString(), Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}