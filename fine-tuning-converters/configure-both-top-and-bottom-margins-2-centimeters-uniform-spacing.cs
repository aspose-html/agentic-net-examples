// Configure PdfRenderingOptions to set both top and bottom margins to 2 centimeters for uniform spacing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
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

            // Define margins: top and bottom = 2 cm (≈0.787402 inches), left and right = 0
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0),               // left
                Aspose.Html.Drawing.Length.FromInches(0.787402),        // top
                Aspose.Html.Drawing.Length.FromInches(0),               // right
                Aspose.Html.Drawing.Length.FromInches(0.787402)         // bottom
            );

            // Define page size (A4 in points: 595x842)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);

            // Apply page setup
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