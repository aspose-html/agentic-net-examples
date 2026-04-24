// Access the document's Links collection to iterate over all <link rel="icon"> elements.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace LinkIconExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the HTML document (replace with your file path or URL)
                var document = new HTMLDocument("input.html");

                // Access the Links collection
                HTMLCollection links = document.Links;

                // Iterate over all link elements
                for (int i = 0; i < links.Length; i++)
                {
                    var element = links[i] as Element;
                    if (element == null) continue;

                    var linkElement = element as HTMLLinkElement;
                    if (linkElement != null && string.Equals(linkElement.Rel, "icon", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(linkElement.Href);
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