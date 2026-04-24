// Resolve each icon href attribute to an absolute URL using Url class and document BaseURI.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Net;

namespace ResolveIconHref
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load HTML document from a URL or file path
                string address = "https://example.com";
                HTMLDocument document = new HTMLDocument(address);

                // Get all <link> elements
                HTMLCollection links = document.GetElementsByTagName("link");

                // Iterate through the collection
                for (int i = 0; i < links.Length; i++)
                {
                    // Cast node to Element
                    Element linkElement = (Element)links[i];

                    // Check if the link is an icon (rel contains "icon")
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel) || !rel.Contains("icon"))
                        continue;

                    // Get the href attribute
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve href to an absolute URL using document's BaseURI
                    Url absoluteUrl = new Url(href, document.BaseURI);

                    // Output the resolved absolute URL
                    Console.WriteLine(absoluteUrl.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}