// Load an HTML page, extract its favicon URL, download the icon to local storage.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the page to process
            string pageUrl = "https://example.com";

            // Load the HTML page
            HTMLDocument document = new HTMLDocument(pageUrl);

            // Locate the <link rel="icon" ...> element
            HTMLCollection links = document.GetElementsByTagName("link");
            string faviconHref = null;
            for (int i = 0; i < links.Length; i++)
            {
                Element linkElement = (Element)links[i];
                string rel = linkElement.GetAttribute("rel");
                if (!string.IsNullOrEmpty(rel) && rel.ToLowerInvariant().Contains("icon"))
                {
                    faviconHref = linkElement.GetAttribute("href");
                    if (!string.IsNullOrEmpty(faviconHref))
                        break;
                }
            }

            if (string.IsNullOrEmpty(faviconHref))
            {
                Console.WriteLine("Favicon not found.");
                return;
            }

            // Resolve the favicon URL against the document's base URI
            Url faviconUrl = new Url(faviconHref, document.BaseURI);
            string faviconUrlString = faviconUrl.ToString();

            // Download the favicon using Aspose.Html network APIs
            HTMLDocument downloadDoc = new HTMLDocument();
            Url url = new Url(faviconUrlString);
            RequestMessage request = new RequestMessage(url);
            ResponseMessage response = downloadDoc.Context.Network.Send(request);
            if (!response.IsSuccess)
            {
                Console.WriteLine("Failed to download favicon.");
                return;
            }
            byte[] data = response.Content.ReadAsByteArray();

            // Save the favicon to a local file
            string outputPath = "favicon.ico";
            File.WriteAllBytes(outputPath, data);
            Console.WriteLine($"Favicon saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}