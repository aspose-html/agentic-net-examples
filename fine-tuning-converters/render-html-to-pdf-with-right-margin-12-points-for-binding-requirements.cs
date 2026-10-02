// Render HTML to PDF with custom right margin of 12 points to accommodate binding requirements.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set up PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Define margins (left, top, right, bottom) in inches.
            // Right margin is 12 points = 12/72 inches = 0.1666667 inches.
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5),   // left
                Aspose.Html.Drawing.Length.FromInches(0.5),   // top
                Aspose.Html.Drawing.Length.FromInches(0.1666667), // right (12 points)
                Aspose.Html.Drawing.Length.FromInches(0.5)    // bottom
            );

            // Define page size (A4 in points: 595 x 842)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842);

            // Create a page with the size and margin
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);

            // Apply the page setup to the rendering options
            options.PageSetup.AnyPage = page;

            // Create PDF device and render
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);

            Console.WriteLine("PDF successfully created at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}