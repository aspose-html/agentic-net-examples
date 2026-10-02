// Convert HTML content to SVG using SvgSaveOptions.

using System;

namespace HTMLToSvgExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg></body></html>";
                string tempSvg = "temp.svg";
                Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                document.Save(tempSvg);
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvg);
                Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
                string outputPath = "output.svg";
                svgDoc.Save(outputPath, options);
                Console.WriteLine("SVG saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}