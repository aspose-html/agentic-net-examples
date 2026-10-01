// Export Markdown content as an SVG vector graphic by passing SvgSaveOptions to ConvertHTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdownContent = "# Sample Heading\nSome **bold** text.";
            string htmlContent = $"<pre>{markdownContent}</pre>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("file:///");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the HTML document as an intermediate SVG file
            string tempSvgPath = "temp.svg";
            document.Save(tempSvgPath);

            // Load the intermediate SVG and save it with SVG-specific options
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);
            Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
            string outputPath = "markdown.svg";
            svgDoc.Save(outputPath, options);

            Console.WriteLine($"SVG saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}