// Extract all link elements with rel="preload" and list their resource URLs for performance audit.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<link rel=\"preload\" href=\"style.css\" as=\"style\">" +
                                 "<link rel=\"preload\" href=\"script.js\" as=\"script\">" +
                                 "<link rel=\"stylesheet\" href=\"main.css\">" +
                                 "</head><body></body></html>";

            HTMLDocument document = new HTMLDocument(htmlContent);
            HTMLCollection linkElements = document.GetElementsByTagName("link");

            List<string> preloadUrls = new List<string>();

            for (int i = 0; i < linkElements.Length; i++)
            {
                Element link = linkElements[i] as Element;
                if (link != null)
                {
                    string rel = link.GetAttribute("rel");
                    if (string.Equals(rel, "preload", StringComparison.OrdinalIgnoreCase))
                    {
                        string href = link.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            preloadUrls.Add(href);
                        }
                    }
                }
            }

            Console.WriteLine("Preload resource URLs:");
            foreach (string url in preloadUrls)
            {
                Console.WriteLine(url);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}