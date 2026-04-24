// Create a reusable method that accepts a URL and returns a list of absolute image URLs.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Net;

namespace ImageUrlExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Example URL; replace with desired page
                string url = "https://example.com";
                List<string> imageUrls = GetAbsoluteImageUrls(url);
                foreach (var imgUrl in imageUrls)
                {
                    Console.WriteLine(imgUrl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Returns a list of absolute image URLs found in the HTML document at the given URL
        static List<string> GetAbsoluteImageUrls(string pageUrl)
        {
            // Load the HTML document from the specified URL
            HTMLDocument document = new HTMLDocument(pageUrl);
            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");
            var result = new List<string>();
            // Iterate through the collection
            for (int i = 0; i < images.Length; i++)
            {
                // Cast each item to an Element
                Element imgElement = (Element)images[i];
                // Retrieve the src attribute
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;
                // Resolve to an absolute URL using the document's BaseURI
                Url absoluteUrl = new Url(src, document.BaseURI);
                result.Add(absoluteUrl.ToString());
            }
            return result;
        }
    }
}