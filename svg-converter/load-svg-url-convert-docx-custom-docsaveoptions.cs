// Load an SVG from a URL and convert it to DOCX with custom DocSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the SVG to convert
            string svgUrl = "https://example.com/sample.svg";

            // Output DOCX file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.docx");

            // Create custom DocSaveOptions
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define page size and margins
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(800, 600);
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

            // Apply custom page setup
            options.PageSetup.AnyPage = page;

            // Convert SVG from URL to DOCX using the custom options
            Aspose.Html.Converters.Converter.ConvertSVG(svgUrl, string.Empty, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}