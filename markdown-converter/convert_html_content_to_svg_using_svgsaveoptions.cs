// Convert HTML content to SVG using SvgSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg></body></html>";
            string tempSvgPath = "temp.svg";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("http://example.com");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Save(tempSvgPath);
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);
            Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
            string outputPath = "output.svg";
            svgDoc.Save(outputPath, options);
            Console.WriteLine("HTML content successfully converted to SVG: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}