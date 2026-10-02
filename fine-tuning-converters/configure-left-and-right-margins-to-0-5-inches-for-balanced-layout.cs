// Configure PdfRenderingOptions to set both left and right margins to 0.5 inches for balanced layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file path and create a minimal sample if it doesn't exist
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Define output PDF file path
            string pdfPath = "output.pdf";

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Create PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Define margins: top=0, right=0.5in, bottom=0, left=0.5in
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0),      // top
                Aspose.Html.Drawing.Length.FromInches(0.5),    // right
                Aspose.Html.Drawing.Length.FromInches(0),      // bottom
                Aspose.Html.Drawing.Length.FromInches(0.5)     // left
            );

            // Define page size (e.g., A4: 595x842 points)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842);

            // Create page setup with the size and margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Create PDF device and render the document
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}