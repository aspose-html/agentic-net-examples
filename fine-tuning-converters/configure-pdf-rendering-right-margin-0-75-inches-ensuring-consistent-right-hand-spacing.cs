// Configure PdfRenderingOptions to set right margin to 0.75 inches, ensuring consistent right‑hand spacing.

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

            // Configure PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Define margins (left, top, right, bottom) in inches
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5), // left
                Aspose.Html.Drawing.Length.FromInches(0.5), // top
                Aspose.Html.Drawing.Length.FromInches(0.75), // right
                Aspose.Html.Drawing.Length.FromInches(0.5)  // bottom
            );

            // Define page size (e.g., A4: 595x842 points)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842);

            // Create page setup
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Render to PDF
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}