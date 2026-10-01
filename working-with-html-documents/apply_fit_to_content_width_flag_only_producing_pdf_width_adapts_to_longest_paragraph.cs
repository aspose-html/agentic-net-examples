// Apply FitToContentWidth flag only, producing a PDF where width adapts to longest paragraph.

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

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF rendering options
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth |
                                                  Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

            // Define margins (1 inch on each side)
            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1));

            // Define page size (8.5 x 11 inches)
            var size = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            // Apply page size and margins
            var page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Render the document to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF successfully generated at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}