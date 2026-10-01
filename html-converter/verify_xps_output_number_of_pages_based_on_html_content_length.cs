// Verify that XPS output contains the expected number of pages based on HTML content length.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content with many paragraphs to span multiple pages
            int paragraphCount = 100;
            string paragraphs = string.Concat(Enumerable.Range(1, paragraphCount).Select(i => $"<p>Paragraph {i}</p>"));
            string htmlContent = $"<html><body>{paragraphs}</body></html>";

            // Create a temporary HTML file
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set up XPS rendering options with a specific page size (6x9 inches)
            Aspose.Html.Rendering.Xps.XpsRenderingOptions options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            Aspose.Html.Drawing.Page anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(6),
                    Aspose.Html.Drawing.Length.FromInches(9)));
            options.PageSetup.AnyPage = anyPage;

            // Define output XPS file path
            string xpsPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Render HTML to XPS
            Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, xpsPath);
            document.RenderTo(device);

            // Count pages in the generated XPS file -- an XPS file is an OPC
            // (zip-based) package, so ZipArchive can enumerate its parts
            // without requiring the separate System.IO.Packaging assembly.
            int actualPageCount;
            using (ZipArchive archive = ZipFile.OpenRead(xpsPath))
            {
                actualPageCount = archive.Entries
                    .Count(e => e.FullName.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase));
            }

            // Estimate expected pages (simple heuristic: 30 paragraphs per page)
            int expectedPageCount = (paragraphCount / 30) + 1;

            // Verify and output the result
            Console.WriteLine($"Expected pages: {expectedPageCount}");
            Console.WriteLine($"Actual pages:   {actualPageCount}");
            Console.WriteLine(actualPageCount == expectedPageCount
                ? "Page count verification succeeded."
                : "Page count verification failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
