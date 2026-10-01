// Enable automatic detection and correction of broken links during website‑to‑HTML conversion.

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
            string sourceUrl = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);
            List<string> brokenLinks = new List<string>();

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs against the document's base URI
                string resolvedUrl = new Uri(new Uri(document.BaseURI), href).AbsoluteUri;

                // Create request and send it
                RequestMessage request = new RequestMessage(resolvedUrl);
                ResponseMessage response = document.Context.Network.Send(request);

                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl);
                }
            }

            Console.WriteLine("Broken links found:");
            foreach (string link in brokenLinks)
            {
                Console.WriteLine(link);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}