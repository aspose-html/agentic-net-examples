// Collect all <link> elements with rel='icon' attribute from the loaded HTML document.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with link icons
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<link rel=\"icon\" href=\"favicon.ico\" />" +
                                 "<link rel=\"stylesheet\" href=\"styles.css\" />" +
                                 "<link rel=\"icon\" href=\"https://example.com/icon.png\" />" +
                                 "</head><body><h1>Hello World</h1></body></html>";

            // Load HTML document from inline content
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Get all <link> elements
                HTMLCollection linkElements = document.GetElementsByTagName("link");
                List<string> iconHrefs = new List<string>();

                for (int i = 0; i < linkElements.Length; i++)
                {
                    Element link = linkElements[i] as Element;
                    if (link != null)
                    {
                        string rel = link.GetAttribute("rel");
                        if (!string.IsNullOrEmpty(rel) && rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                        {
                            string href = link.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href))
                            {
                                iconHrefs.Add(href);
                            }
                        }
                    }
                }

                // Output collected icon hrefs
                Console.WriteLine("Icon links found:");
                foreach (string href in iconHrefs)
                {
                    Console.WriteLine(href);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}