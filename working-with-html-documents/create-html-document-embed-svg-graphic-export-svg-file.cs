// Create an HTML document, embed an SVG graphic, and export the result as an SVG file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' /></svg></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            string tempSvgPath = "temp.svg";
            document.Save(tempSvgPath);

            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);
            Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();

            string outputPath = "output.svg";
            svgDoc.Save(outputPath, options);

            Console.WriteLine("SVG exported to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}