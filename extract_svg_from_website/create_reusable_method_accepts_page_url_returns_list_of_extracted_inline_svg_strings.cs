// Create a reusable method that accepts a page URL and returns a list of extracted inline SVG strings.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Example URL containing inline SVG elements
            string url = "https://example.com/page-with-svgs.html";

            // Extract SVG markup strings
            List<string> svgStrings = ExtractInlineSvgStrings(url);

            // Output the number of extracted SVGs
            Console.WriteLine($"Extracted {svgStrings.Count} inline SVG elements.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Returns a list of outer HTML strings for each inline <svg> element found in the page.
    static List<string> ExtractInlineSvgStrings(string pageUrl)
    {
        // Load the HTML document from the specified URL
        HTMLDocument document = new HTMLDocument(pageUrl);

        // Get all <svg> elements in the document
        HTMLCollection svgs = document.GetElementsByTagName("svg");

        List<string> result = new List<string>();

        // Iterate through the collection and collect each element's outer HTML
        for (int i = 0; i < svgs.Length; i++)
        {
            Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
            string markup = svgElement.OuterHTML;
            result.Add(markup);
        }

        return result;
    }
}