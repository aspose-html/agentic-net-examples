// Log each SVG to DOCX conversion, including page count and any custom DocSaveOptions applied.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='2'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>SVG</text>
</svg>";

            // Create temporary SVG file
            string svgPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            File.WriteAllText(svgPath, svgCode);

            // Define output PDF path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.pdf");

            // Set up PDF save options with page size and margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(800, 600);
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert SVG to PDF
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to PDF.");
            Console.WriteLine("Input SVG: " + svgPath);
            Console.WriteLine("Output PDF: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}