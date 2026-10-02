// Verify that XPS output contains the expected number of pages based on HTML content length.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content with two page breaks
            string htmlContent = @"
                <html>
                <head><style>div{page-break-after:always;}</style></head>
                <body>
                    <div>Page 1 content</div>
                    <div>Page 2 content</div>
                </body>
                </html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set up XPS rendering options with a small page size to force pagination
            var options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            var anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(3),
                    Aspose.Html.Drawing.Length.FromInches(3)));
            options.PageSetup.AnyPage = anyPage;

            // Define output XPS path
            string xpsPath = Path.Combine(Path.GetTempPath(), "output.xps");

            // Render HTML to XPS
            using (var device = new Aspose.Html.Rendering.Xps.XpsDevice(options, xpsPath))
            {
                document.RenderTo(device);
            }

            // Count pages in the generated XPS file
            int pageCount = 0;
            using (var archive = ZipFile.OpenRead(xpsPath))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase))
                    {
                        pageCount++;
                    }
                }
            }

            // Expected number of pages based on HTML content
            int expectedPageCount = 2;

            Console.WriteLine($"Expected pages: {expectedPageCount}");
            Console.WriteLine($"Actual pages:   {pageCount}");
            Console.WriteLine(pageCount == expectedPageCount
                ? "Page count verification succeeded."
                : "Page count verification failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}