// Parse the <base> tag in the HTML document to correctly resolve relative SVG URLs.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content containing a <base> tag and an inline SVG with relative URLs
            string htmlContent = @"<html><head><base href='https://example.com/assets/'></head><body><svg xmlns='http://www.w3.org/2000/svg'><image href='image.png' width='100' height='100'/></svg></body></html>";

            // Load the HTML document (base URI will be set later from the <base> element)
            var htmlDoc = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Retrieve the href attribute of the <base> element
            string baseHref = "";
            var baseElements = htmlDoc.GetElementsByTagName("base");
            if (baseElements.Length > 0)
            {
                var baseElem = baseElements[0] as Element;
                baseHref = baseElem?.GetAttribute("href") ?? "";
            }

            // Extract the SVG markup from the HTML document
            var svgElements = htmlDoc.GetElementsByTagName("svg");
            if (svgElements.Length == 0)
                return;
            var svgElem = svgElements[0] as Element;
            string svgMarkup = svgElem?.OuterHTML ?? "";

            // Load the SVG document using the extracted markup and the base URI
            SVGDocument svgDoc = new SVGDocument(svgMarkup, baseHref);

            // Output the serialized SVG markup (relative URLs are resolved using the base URI)
            Console.WriteLine(svgDoc.DocumentElement.OuterHTML);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}