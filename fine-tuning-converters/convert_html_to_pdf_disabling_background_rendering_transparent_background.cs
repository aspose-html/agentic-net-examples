// Convert HTML to PDF while disabling background rendering to produce a transparent‑background document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file
            File.WriteAllText(htmlPath, "<html><body><h1>Hello, World!</h1></body></html>");

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure rendering options to disable background (transparent)
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.Transparent;

            // Create PDF device with the specified options
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);

            // Render HTML to PDF
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}