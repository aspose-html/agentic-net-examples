// Export Markdown content as an SVG vector graphic by passing SvgSaveOptions to ConvertHTML.

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Title\nThis is a **markdown** paragraph.";
            string htmlContent = "<html><body><h1>Sample Title</h1><p>This is a <b>markdown</b> paragraph.</p></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            string tempSvg = "temp.svg";
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