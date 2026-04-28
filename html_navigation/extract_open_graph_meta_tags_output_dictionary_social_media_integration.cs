// Extract Open Graph meta tags and output them as a dictionary for social media integration.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace OpenGraphExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // URL of the HTML page to process
                string url = "https://example.com";

                // Load the HTML document from the specified URL
                HTMLDocument document = new HTMLDocument(url);

                // Collection to store extracted Open Graph tags
                Dictionary<string, string> openGraphTags = new Dictionary<string, string>();

                // Retrieve all <meta> elements in the document
                HTMLCollection metaElements = document.GetElementsByTagName("meta");

                // Iterate through each meta element
                for (int i = 0; i < metaElements.Length; i++)
                {
                    // Cast the element to a generic DOM element
                    Element meta = metaElements[i] as Element;
                    if (meta == null) continue;

                    // Get the value of the "property" attribute
                    string property = meta.GetAttribute("property");
                    if (string.IsNullOrEmpty(property) || !property.StartsWith("og:")) continue;

                    // Get the value of the "content" attribute
                    string content = meta.GetAttribute("content");
                    if (string.IsNullOrEmpty(content)) continue;

                    // Store the Open Graph tag in the dictionary
                    openGraphTags[property] = content;
                }

                // Output the extracted Open Graph tags
                foreach (var kvp in openGraphTags)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}