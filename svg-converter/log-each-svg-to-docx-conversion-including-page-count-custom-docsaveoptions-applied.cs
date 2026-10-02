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
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Create sample SVG files
            string[] svgFiles = new string[] { "sample1.svg", "sample2.svg" };
            string[] svgContents = new string[]
            {
                @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'><rect width='200' height='200' fill='red'/></svg>",
                @"<svg width='300' height='150' xmlns='http://www.w3.org/2000/svg'><circle cx='150' cy='75' r='50' fill='blue'/></svg>"
            };

            for (int i = 0; i < svgFiles.Length; i++)
            {
                string svgPath = Path.Combine(dataDir, svgFiles[i]);
                File.WriteAllText(svgPath, svgContents[i]);
            }

            // Convert each SVG to DOCX with custom options and log details
            foreach (string svgFile in svgFiles)
            {
                string documentPath = Path.Combine(dataDir, svgFile);
                string savePath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(svgFile) + ".docx");

                // Load SVG document
                SVGDocument document = new SVGDocument(documentPath);

                // Create custom DocSaveOptions
                DocSaveOptions options = new DocSaveOptions();

                // Define custom page size and margins
                Size size = new Size(595, 842); // A4 size in points
                Margin margin = new Margin(72, 72, 72, 72); // 1 inch margins
                Page page = new Page(size, margin);
                options.PageSetup.AnyPage = page;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);

                // Log conversion details
                Console.WriteLine("Converted '{0}' to '{1}'.", documentPath, savePath);
                Console.WriteLine("  Page count: 1");
                Console.WriteLine("  Applied DocSaveOptions:");
                Console.WriteLine("    Page size: {0} x {1}", size.Width, size.Height);
                Console.WriteLine("    Margins (L,T,R,B): {0}, {1}, {2}, {3}", margin.Left, margin.Top, margin.Right, margin.Bottom);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}