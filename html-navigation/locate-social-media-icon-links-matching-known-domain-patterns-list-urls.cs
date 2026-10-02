// Locate social media icon links by matching known domain patterns and list their URLs.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"
                <html>
                <body>
                    <a href='https://twitter.com/example'><img src='icon1.png' alt='Twitter'></a>
                    <a href='https://www.facebook.com/example'><img src='icon2.png' alt='Facebook'></a>
                    <a href='https://example.com/about'>About Us</a>
                    <a href='/contact'>Contact</a>
                    <a href='https://instagram.com/example'><img src='icon3.png' alt='Instagram'></a>
                </body>
                </html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                List<string> socialLinks = new List<string>();
                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                    string url = resolvedUrl.ToString();

                    if (url.Contains("facebook.com", StringComparison.OrdinalIgnoreCase) ||
                        url.Contains("twitter.com", StringComparison.OrdinalIgnoreCase) ||
                        url.Contains("instagram.com", StringComparison.OrdinalIgnoreCase) ||
                        url.Contains("linkedin.com", StringComparison.OrdinalIgnoreCase) ||
                        url.Contains("youtube.com", StringComparison.OrdinalIgnoreCase) ||
                        url.Contains("pinterest.com", StringComparison.OrdinalIgnoreCase))
                    {
                        socialLinks.Add(url);
                    }
                }

                Console.WriteLine("Social media links found:");
                foreach (string link in socialLinks)
                {
                    Console.WriteLine(link);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}