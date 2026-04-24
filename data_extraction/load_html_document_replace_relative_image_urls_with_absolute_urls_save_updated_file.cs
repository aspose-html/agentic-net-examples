// Load an HTML document, replace all relative image URLs with absolute URLs, and save the updated file.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Replace relative src attributes with absolute URLs
            foreach (Element img in images)
            {
                string src = img.GetAttribute("src");
                if (!string.IsNullOrEmpty(src) && !Uri.IsWellFormedUriString(src, UriKind.Absolute))
                {
                    // Resolve to absolute URL using the document's base URI
                    Url absoluteUrl = new Url(src, document.BaseURI);
                    img.SetAttribute("src", absoluteUrl.ToString());
                }
            }

            // Save the updated document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}