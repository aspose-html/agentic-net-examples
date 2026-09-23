// Access the document's Links collection to iterate over all <link rel="icon"> elements.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><head><link rel=\"icon\" href=\"favicon.ico\"><link rel=\"icon\" href=\"/images/icon.png\"><link rel=\"stylesheet\" href=\"style.css\"></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            List<string> iconLinks = new List<string>();
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}