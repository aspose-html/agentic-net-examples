// Locate social media icon links by matching known domain patterns and list their URLs.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL or file path
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com");

            // List of known social media domain patterns
            List<string> socialDomains = new List<string>
            {
                "facebook.com",
                "twitter.com",
                "instagram.com",
                "linkedin.com",
                "youtube.com"
            };

            // Iterate over all link elements in the document
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs to absolute URLs
                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                string absoluteUrl = resolvedUrl.ToString();

                // Check if the URL matches any known social media domain
                foreach (string domain in socialDomains)
                {
                    if (absoluteUrl.IndexOf(domain, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine(absoluteUrl);
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}