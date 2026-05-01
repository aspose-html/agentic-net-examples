// Create an HTML document, embed an SVG graphic, and export the result as an SVG file.

using System;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Dom.Svg.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello</h1><svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' /></svg></body></html>";
            string tempSvg = "temp.svg";
            Url baseUri = new Url("file:///");
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
            document.Save(tempSvg);
            SVGDocument svgDoc = new SVGDocument(tempSvg);
            SVGSaveOptions options = new SVGSaveOptions();
            string outputPath = "output.svg";
            svgDoc.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}