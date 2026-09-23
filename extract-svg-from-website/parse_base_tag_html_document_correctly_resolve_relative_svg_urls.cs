// Parse the <base> tag in the HTML document to correctly resolve relative SVG URLs.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><base href=\"https://example.com/assets/\"/></head><body><svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><image href=\"image.png\" width=\"100\" height=\"100\"/></svg></body></html>";

            // Create HTMLDocument with a dummy base URL
            Aspose.Html.Url dummyBase = new Aspose.Html.Url("https://example.com/");
            Aspose.Html.HTMLDocument htmlDoc = new Aspose.Html.HTMLDocument(htmlContent, dummyBase);

            // Retrieve the <base> element's href attribute
            Aspose.Html.HTMLElement baseElement = (Aspose.Html.HTMLElement)htmlDoc.GetElementsByTagName("base")[0];
            string baseHref = baseElement.GetAttribute("href");

            // Extract the SVG element's outer HTML
            Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)htmlDoc.GetElementsByTagName("svg")[0];
            string svgContent = svgElement.OuterHTML;

            // Create an SVGDocument using the extracted SVG and the base URL
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, baseHref);

            // Output the resulting SVG markup
            System.Console.WriteLine(svgDoc.DocumentElement.OuterHTML);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}