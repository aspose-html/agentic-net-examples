// Convert relative URLs in anchor tags to absolute URLs using the document’s base URL.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file with relative links
            string htmlContent = "<html><head><base href=\"https://example.com/sub/\"/></head><body><a href=\"page.html\">Link</a><a href=\"/abs/page2.html\">AbsLink</a></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Convert relative hrefs to absolute URLs
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Url resolvedUrl = new Url(href, document.BaseURI);
                linkElement.SetAttribute("href", resolvedUrl.ToString());
            }

            // Output the resulting HTML
            string resultHtml = document.DocumentElement.OuterHTML;
            Console.WriteLine(resultHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}