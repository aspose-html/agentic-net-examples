// Convert HTML content to SVG using SvgSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
            string tempSvg = "temp.svg";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Save(tempSvg);
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvg);
            Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
            string outputPath = "output.svg";
            svgDoc.Save(outputPath, options);
            System.Console.WriteLine("SVG saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}