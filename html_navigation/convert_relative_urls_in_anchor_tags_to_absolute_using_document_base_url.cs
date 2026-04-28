// Convert relative URLs in anchor tags to absolute URLs using the document’s base URL.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL (base URL)
            string sourceUrl = "https://example.com/page.html";
            HTMLDocument document = new HTMLDocument(sourceUrl);

            // Iterate over all anchor elements and convert relative hrefs to absolute URLs
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Url absoluteUrl = new Url(href, document.BaseURI);
                linkElement.SetAttribute("href", absoluteUrl.ToString());
            }

            // Output the modified HTML
            string modifiedHtml = document.DocumentElement.OuterHTML;
            Console.WriteLine(modifiedHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}