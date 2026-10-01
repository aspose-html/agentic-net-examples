// Verify that XPS output contains the expected number of pages based on HTML content length.

using System;
using System.IO;
using System.IO.Packaging;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = @"<html><body>" +
                                 "<h1>Sample Document</h1>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "<p>This is a paragraph that will be repeated to generate multiple pages.</p>" +
                                 "</body></html>";

            string documentPath = Path.Combine(Environment.CurrentDirectory, "input.html");
            File.WriteAllText(documentPath, htmlContent);

            // Define output XPS path
            string savePath = Path.Combine(Environment.CurrentDirectory, "output.xps");

            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            // Configure XPS rendering options with custom page size (5 inches x 2 inches)
            Aspose.Html.Rendering.Xps.XpsRenderingOptions options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            Aspose.Html.Drawing.Page anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(5),
                    Aspose.Html.Drawing.Length.FromInches(2)));
            options.PageSetup.AnyPage = anyPage;

            // Render to XPS
            Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, savePath);
            document.RenderTo(device);

            // Verify number of pages in the generated XPS
            int pageCount = 0;
            using (Package package = Package.Open(savePath, FileMode.Open, FileAccess.Read))
            {
                foreach (PackagePart part in package.GetParts())
                {
                    if (part.Uri.OriginalString.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase))
                    {
                        pageCount++;
                    }
                }
            }

            // Expected page count based on content (example expectation)
            int expectedPages = 3; // Adjust based on actual content and page size

            Console.WriteLine($"Generated XPS page count: {pageCount}");
            Console.WriteLine($"Expected page count: {expectedPages}");
            Console.WriteLine(pageCount == expectedPages
                ? "Page count verification succeeded."
                : "Page count verification failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}