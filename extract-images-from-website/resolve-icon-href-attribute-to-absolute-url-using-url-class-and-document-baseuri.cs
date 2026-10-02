// Resolve each icon href attribute to an absolute URL using Url class and document BaseURI.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"icon\" href=\"/images/favicon.ico\"><link rel=\"icon\" href=\"http://cdn.example.com/favicon2.ico\"></head><body></body></html>";
            // Load HTML with a base URI for relative URL resolution
            HTMLDocument document = new HTMLDocument(htmlContent, "http://example.com/");

            HTMLCollection links = document.GetElementsByTagName("link");
            for (int i = 0; i < links.Length; i++)
            {
                Element linkElement = (Element)links[i];
                string rel = linkElement.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel) || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Url absoluteUrl = new Url(href, document.BaseURI);
                Console.WriteLine(absoluteUrl);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}