// Locate social media icon links by matching known domain patterns and list their URLs.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href=\"https://www.facebook.com/example\"><img src=\"fb.png\"/></a>" +
                                 "<a href=\"https://twitter.com/example\"><img src=\"tw.png\"/></a>" +
                                 "<a href=\"https://example.com\"><img src=\"logo.png\"/></a>" +
                                 "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
            {
                List<string> socialLinks = new List<string>();

                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    string lowerHref = href.ToLowerInvariant();
                    if (lowerHref.Contains("facebook.com") ||
                        lowerHref.Contains("twitter.com") ||
                        lowerHref.Contains("instagram.com") ||
                        lowerHref.Contains("linkedin.com") ||
                        lowerHref.Contains("youtube.com") ||
                        lowerHref.Contains("pinterest.com"))
                    {
                        socialLinks.Add(href);
                    }
                }

                Console.WriteLine("Social media links found:");
                foreach (string url in socialLinks)
                {
                    Console.WriteLine(url);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}