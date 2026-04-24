// Detect and skip duplicate SVG markup by comparing OuterHTML strings before writing files.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file containing inline SVG elements
            string htmlPath = "input.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Retrieve all <svg> elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Keep track of already processed SVG markup
            HashSet<string> seenMarkups = new HashSet<string>();

            // Iterate through each SVG element
            for (int i = 0; i < svgs.Length; i++)
            {
                // Cast the collection item to HTMLElement to access OuterHTML
                HTMLElement svgElement = (HTMLElement)svgs[i];

                // Get the full SVG markup
                string markup = svgElement.OuterHTML;

                // Skip if this markup has already been processed
                if (!seenMarkups.Add(markup))
                    continue;

                // Define a unique output file name for the SVG
                string outputPath = $"output_{i}.svg";

                // Create an SVGDocument from the markup (empty base URI)
                SVGDocument svgDoc = new SVGDocument(markup, "");

                // Save the SVG document to a file
                svgDoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}