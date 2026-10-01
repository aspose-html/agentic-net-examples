// Verify that XPS output contains the expected number of pages based on HTML content length.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Xps;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output XPS file paths
            string htmlPath = "sample.html";
            string xpsPath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                // Generate HTML content with enough length to span multiple pages
                string htmlContent = "<html><body>" + new string('A', 2500) + "</body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set up XPS rendering options (default options are sufficient)
            XpsRenderingOptions options = new XpsRenderingOptions();

            // Render the HTML document to XPS
            using (XpsDevice device = new XpsDevice(options, xpsPath))
            {
                document.RenderTo(device);
            }

            // Count the number of pages in the generated XPS file
            int pageCount = 0;
            using (ZipArchive archive = ZipFile.OpenRead(xpsPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // XPS page parts end with ".fpage"
                    if (entry.FullName.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase))
                    {
                        pageCount++;
                    }
                }
            }

            // Determine expected page count based on HTML content length (simple heuristic)
            string htmlText = File.ReadAllText(htmlPath);
            int expectedPages = (htmlText.Length / 1000) + 1;

            // Output the results
            Console.WriteLine($"Expected pages: {expectedPages}");
            Console.WriteLine($"Actual pages in XPS: {pageCount}");
            if (pageCount == expectedPages)
            {
                Console.WriteLine("Page count matches expected.");
            }
            else
            {
                Console.WriteLine("Page count does NOT match expected.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}