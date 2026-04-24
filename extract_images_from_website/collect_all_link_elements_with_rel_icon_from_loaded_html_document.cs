// Collect all <link> elements with rel='icon' attribute from the loaded HTML document.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace LinkIconCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "sample.html";
                HTMLDocument document = new HTMLDocument(htmlPath);
                HTMLCollection linkElements = document.GetElementsByTagName("link");
                for (int i = 0; i < linkElements.Length; i++)
                {
                    HTMLElement link = linkElements[i] as HTMLElement;
                    if (link != null)
                    {
                        string rel = link.GetAttribute("rel");
                        if (!string.IsNullOrEmpty(rel) && rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                        {
                            string href = link.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href))
                            {
                                Console.WriteLine(href);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}