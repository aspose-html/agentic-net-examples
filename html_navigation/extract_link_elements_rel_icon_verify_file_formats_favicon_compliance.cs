// Extract all link elements with rel="icon" and verify their file formats for favicon compliance.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            HTMLDocument doc = new HTMLDocument("input.html");

            // Collect links that are not compliant with common favicon formats
            List<string> nonCompliantIcons = new List<string>();

            // Iterate over all link elements in the document
            foreach (Element link in doc.Links)
            {
                // Check if the link has rel="icon"
                string rel = link.GetAttribute("rel");
                if (string.Equals(rel, "icon", StringComparison.OrdinalIgnoreCase))
                {
                    // Get the href attribute (the icon URL)
                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the URL against the document's base URI
                    Url resolvedUrl = new Url(href, doc.BaseURI);

                    // Determine the file extension
                    string extension = System.IO.Path.GetExtension(resolvedUrl.ToString()).ToLowerInvariant();

                    // Acceptable favicon formats: .ico, .png, .svg
                    if (extension != ".ico" && extension != ".png" && extension != ".svg")
                    {
                        nonCompliantIcons.Add(resolvedUrl.ToString());
                    }
                }
            }

            // Output the results
            Console.WriteLine("Non‑compliant favicon links:");
            foreach (string url in nonCompliantIcons)
            {
                Console.WriteLine(url);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}