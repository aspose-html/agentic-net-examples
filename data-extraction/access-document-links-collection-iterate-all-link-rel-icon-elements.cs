// Access the document's Links collection to iterate over all <link rel="icon"> elements.

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
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"icon\" href=\"favicon.ico\"><link rel=\"stylesheet\" href=\"style.css\"><link rel=\"icon\" href=\"/images/icon.png\"></head><body></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
            List<string> iconLinks = new List<string>();

            foreach (Element linkElement in document.Links)
            {
                string rel = linkElement.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel) || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = linkElement.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    iconLinks.Add(href);
                }
            }

            Console.WriteLine("Icon links found:");
            foreach (string href in iconLinks)
            {
                Console.WriteLine(href);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}