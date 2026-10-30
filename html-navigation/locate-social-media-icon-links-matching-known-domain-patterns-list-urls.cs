// Locate social media icon links by matching known domain patterns and list their URLs.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = @"
                <html>
                    <body>
                        <a href='https://www.facebook.com/example'><img src='fb.png' alt='Facebook'></a>
                        <a href='https://twitter.com/example'><img src='tw.png' alt='Twitter'></a>
                        <a href='https://example.com/about'>About Us</a>
                        <a href='https://www.linkedin.com/company/example'><img src='ln.png' alt='LinkedIn'></a>
                        <a href='https://instagram.com/example'><img src='ig.png' alt='Instagram'></a>
                    </body>
                </html>";

            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                List<string> socialLinks = new List<string>();
                string[] domains = new string[]
                {
                    "facebook.com",
                    "twitter.com",
                    "instagram.com",
                    "linkedin.com",
                    "youtube.com",
                    "pinterest.com",
                    "tiktok.com"
                };

                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Url resolvedUrl = new Url(href, document.BaseURI);
                    string urlString = resolvedUrl.ToString();

                    foreach (string domain in domains)
                    {
                        if (urlString.IndexOf(domain, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            socialLinks.Add(urlString);
                            break;
                        }
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