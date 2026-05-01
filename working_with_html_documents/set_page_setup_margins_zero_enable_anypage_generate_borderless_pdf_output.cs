// Set PageSetup margins to zero, enable AnyPage, and generate a borderless PDF output.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(htmlPath);
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Set all margins to zero inches
            Margin margin = new Margin(
                Length.FromInches(0),
                Length.FromInches(0),
                Length.FromInches(0),
                Length.FromInches(0)
            );

            // Define a page size (width, height) – using zero size as placeholder
            Size size = new Size(0, 0);

            // Create a page with the size and zero margins and assign to AnyPage
            Page page = new Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Render the document to PDF
            PdfDevice device = new PdfDevice(options, pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}