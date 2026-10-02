// Extract all link elements with rel="preload" and list their resource URLs for performance audit.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><head>" +
                          "<link rel='preload' href='style.css' as='style'/>" +
                          "<link rel='preload' href='script.js' as='script'/>" +
                          "<link rel='stylesheet' href='other.css'/>" +
                          "</head><body></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection linkElements = document.GetElementsByTagName("link");
                List<string> preloadUrls = new List<string>();

                for (int i = 0; i < linkElements.Length; i++)
                {
                    Aspose.Html.Dom.Element link = linkElements[i] as Aspose.Html.Dom.Element;
                    if (link == null) continue;

                    string rel = link.GetAttribute("rel");
                    if (!string.Equals(rel, "preload", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Aspose.Html.Url resolved = new Aspose.Html.Url(href, document.BaseURI);
                    preloadUrls.Add(resolved.ToString());
                }

                Console.WriteLine("Preload resource URLs:");
                foreach (string url in preloadUrls)
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