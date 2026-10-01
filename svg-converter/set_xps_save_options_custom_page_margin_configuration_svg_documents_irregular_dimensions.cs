// Set XpsSaveOptions to use a custom page margin configuration for SVG documents with irregular dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string documentPath = "sample.svg";
            string docOutputPath = "output.docx";
            string xpsOutputPath = "output.xps";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(documentPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
                File.WriteAllText(documentPath, svgContent);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(documentPath);

            // Convert SVG to DOC
            var docOptions = new Aspose.Html.Saving.DocSaveOptions();
            var docSize = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
            var docMargin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72); // 1 inch margins
            var docPage = new Aspose.Html.Drawing.Page(docSize, docMargin);
            docOptions.PageSetup.AnyPage = docPage;
            Aspose.Html.Converters.Converter.ConvertSVG(document, docOptions, docOutputPath);
            Console.WriteLine($"SVG converted to DOC: {docOutputPath}");

            // Convert SVG to XPS
            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            xpsOptions.HorizontalResolution = 300;
            xpsOptions.VerticalResolution = 300;
            xpsOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            var xpsSize = new Aspose.Html.Drawing.Size(595, 842);
            var xpsMargin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);
            var xpsPage = new Aspose.Html.Drawing.Page(xpsSize, xpsMargin);
            xpsOptions.PageSetup.AnyPage = xpsPage;
            Aspose.Html.Converters.Converter.ConvertSVG(document, xpsOptions, xpsOutputPath);
            Console.WriteLine($"SVG converted to XPS: {xpsOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}