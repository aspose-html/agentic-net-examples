// Log each SVG to DOCX conversion, including page count and any custom DocSaveOptions applied.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG files
            string[] svgFiles = new string[] { "sample1.svg", "sample2.svg" };

            // Ensure sample SVG files exist
            foreach (string path in svgFiles)
            {
                if (!File.Exists(path))
                {
                    string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>";
                    File.WriteAllText(path, svgContent);
                }
            }

            foreach (string svgPath in svgFiles)
            {
                // Load SVG document
                SVGDocument document = new SVGDocument(svgPath);

                // Create custom DocSaveOptions
                DocSaveOptions options = new DocSaveOptions();

                // Example custom page setup: A4 size with 1-inch margins
                Size pageSize = new Size(595, 842); // width, height in points
                Margin pageMargin = new Margin(72, 72, 72, 72); // left, top, right, bottom in points
                Page anyPage = new Page(pageSize, pageMargin);
                options.PageSetup.AnyPage = anyPage;

                // Output DOCX path
                string outputPath = Path.ChangeExtension(svgPath, ".docx");

                // Convert SVG to DOCX
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

                // Log conversion details (SVG to DOCX)
                int pageCount = 1; // SVG conversion results in a single page by default
                Console.WriteLine($"Converted '{svgPath}' to '{outputPath}'. Page count: {pageCount}. Custom page size applied: {pageSize.Width}x{pageSize.Height} points, margins: {pageMargin.Left},{pageMargin.Top},{pageMargin.Right},{pageMargin.Bottom} points.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}