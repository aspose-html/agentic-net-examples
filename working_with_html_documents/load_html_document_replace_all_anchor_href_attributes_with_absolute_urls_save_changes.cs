// Load an HTML document, replace all anchor href attributes with absolute URLs, and save changes.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;
using Aspose.Html.Collections;

namespace ReplaceAnchorHref
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document from the file
                HTMLDocument document = new HTMLDocument(inputPath);

                // Iterate over all anchor elements in the document
                foreach (Element element in document.Links)
                {
                    // Cast to HTMLAnchorElement to access the Href property
                    HTMLAnchorElement anchor = element as HTMLAnchorElement;
                    if (anchor == null)
                        continue;

                    // Get the original href attribute value
                    string href = anchor.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve relative URLs against the document's base URI
                    Url resolvedUrl = new Url(href, document.BaseURI);
                    // Set the absolute URL back to the anchor
                    anchor.Href = resolvedUrl.ToString();
                }

                // Save the modified document
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}