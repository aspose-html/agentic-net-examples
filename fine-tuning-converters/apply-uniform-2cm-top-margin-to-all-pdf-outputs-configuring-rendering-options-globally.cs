// Apply a uniform 2‑centimeter top margin to all PDF outputs by configuring PdfRenderingOptions globally.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;

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

            // Configure PDF rendering options with a 2 cm top margin
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // 2 centimeters = 0.7874015748 inches
            double topInches = 2.0 / 2.54;

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),   // top
                Aspose.Html.Drawing.Length.FromInches(0),          // right
                Aspose.Html.Drawing.Length.FromInches(0),          // bottom
                Aspose.Html.Drawing.Length.FromInches(0)           // left
            );

            // Define a page size (8 x 11 inches at 96 DPI)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size((int)(8 * 96), (int)(11 * 96));
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            // Render to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}