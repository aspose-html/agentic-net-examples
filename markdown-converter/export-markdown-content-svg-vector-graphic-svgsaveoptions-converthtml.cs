// Export Markdown content as an SVG vector graphic by passing SvgSaveOptions to ConvertHTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Title\n\nThis is **bold** text.";
            string htmlContent = "<html><body><h1>Sample Title</h1><p>This is <strong>bold</strong> text.</p></body></html>";
            string tempSvg = "temp.svg";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Save(tempSvg);
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvg);
            Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
            string outputPath = "output.svg";
            svgDoc.Save(outputPath, options);
            Console.WriteLine("SVG file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}