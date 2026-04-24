// Verify that XPS output contains the expected number of pages based on HTML content length.

using System;
using System.IO;
using System.IO.Packaging;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Xps;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input HTML and output XPS
            string documentPath = "input.html";
            string savePath = "output.xps";

            // Read HTML content to estimate expected page count
            string htmlContent = File.ReadAllText(documentPath);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Configure rendering options with a custom page size (8 x 11 inches)
            XpsRenderingOptions options = new XpsRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(8), Length.FromInches(11)));

            // Render HTML to XPS
            XpsDevice device = new XpsDevice(options, savePath);
            document.RenderTo(device);
            device.Dispose();

            // Count actual pages in the generated XPS file
            int actualPages = CountXpsPages(savePath);

            // Simple heuristic: one page per 1000 characters of HTML
            int expectedPages = (htmlContent.Length / 1000) + 1;

            Console.WriteLine($"Actual pages: {actualPages}");
            Console.WriteLine($"Expected pages (based on content length): {expectedPages}");
            Console.WriteLine(actualPages == expectedPages
                ? "Page count matches expectation."
                : "Page count does not match expectation.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to count FixedPage parts in an XPS package
    static int CountXpsPages(string xpsPath)
    {
        int count = 0;
        using (Package package = Package.Open(xpsPath, FileMode.Open, FileAccess.Read))
        {
            foreach (PackagePart part in package.GetParts())
            {
                if (part.Uri.OriginalString.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
        }
        return count;
    }
}