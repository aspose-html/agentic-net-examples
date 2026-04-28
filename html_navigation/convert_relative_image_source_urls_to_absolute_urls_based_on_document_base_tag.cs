// Convert all relative image source URLs to absolute URLs based on the document’s base tag.

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
            // Load the HTML document from a file or URL
            var document = new HTMLDocument("input.html");

            // Iterate through all <img> elements
            foreach (Element img in document.Images)
            {
                string src = img.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // If the src is already absolute, skip
                if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                    continue;

                // Resolve relative URL to absolute using the document's base URI
                var absoluteUrl = new Url(src, document.BaseURI);
                img.SetAttribute("src", absoluteUrl.ToString());
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}