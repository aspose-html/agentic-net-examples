// Detect broken links by sending HTTP HEAD requests to each extracted URL and logging failures.

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
            string htmlContent = "<html><body>" +
                                 "<a href='https://example.com'>Valid Link</a>" +
                                 "<a href='https://nonexistent.example.invalid'>Broken Link</a>" +
                                 "</body></html>";

            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
            List<string> brokenLinks = new List<string>();

            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Url resolvedUrl = new Url(href, document.BaseURI);
                RequestMessage request = new RequestMessage(resolvedUrl);
                ResponseMessage response = document.Context.Network.Send(request);

                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl.ToString());
                }
            }

            if (brokenLinks.Count == 0)
            {
                Console.WriteLine("No broken links found.");
            }
            else
            {
                Console.WriteLine("Broken links detected:");
                foreach (string url in brokenLinks)
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