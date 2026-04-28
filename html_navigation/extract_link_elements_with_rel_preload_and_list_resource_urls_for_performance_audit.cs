// Extract all link elements with rel="preload" and list their resource URLs for performance audit.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com"; // replace with the target page URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Collections.HTMLCollection linkElements = document.GetElementsByTagName("link");
            for (int i = 0; i < linkElements.Length; i++)
            {
                Aspose.Html.Dom.Element link = (Aspose.Html.Dom.Element)linkElements[i];
                string rel = link.GetAttribute("rel");
                if (!string.IsNullOrEmpty(rel) && rel.Split(' ').Contains("preload"))
                {
                    string href = link.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        Console.WriteLine(href);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}