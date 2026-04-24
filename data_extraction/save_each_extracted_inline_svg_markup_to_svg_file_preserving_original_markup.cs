// Save each extracted inline SVG markup to a .svg file preserving original markup.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page containing inline SVG elements
            string url = "https://example.com/page-with-svgs.html";

            // Load the HTML document from the specified URL
            HTMLDocument document = new HTMLDocument(url);

            // Retrieve all <svg> elements in the document
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Iterate over each SVG element
            for (int i = 0; i < svgs.Length; i++)
            {
                // Cast the node to HTMLElement to access the OuterHTML property
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];

                // Get the original SVG markup
                string markup = svgElement.OuterHTML;

                // Define a file name for the extracted SVG
                string fileName = $"svg_{i}.svg";

                // Create an SVGDocument from the markup using the page URL as the base URI
                SVGDocument svgDoc = new SVGDocument(markup, url);

                // Save the SVG markup to a .svg file
                svgDoc.Save(fileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}