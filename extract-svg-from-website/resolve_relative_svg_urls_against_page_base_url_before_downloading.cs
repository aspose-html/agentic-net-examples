// Resolve relative SVG URLs against the page's base URL before downloading.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing an SVG with a relative image URL
            string htmlContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><image href='images/pic.png' width='200' height='200'/></svg>";

            // Base URL of the page
            Aspose.Html.Url baseUri = new Aspose.Html.Url("https://example.com/page/");

            // Resolve the relative URL against the base URL (demonstration)
            Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(baseUri.ToString(), "images/pic.png");
            Console.WriteLine("Resolved URL: " + resolvedUrl.ToString());

            // Load HTML document with base URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the document as a temporary SVG file
            string tempSvgPath = "temp.svg";
            document.Save(tempSvgPath);

            // Load the saved SVG
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);

            // Save the final SVG to output path
            string outputPath = "output.svg";
            svgDoc.Save(outputPath);

            Console.WriteLine("SVG saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}