// Apply a custom 600x800 pixel page size to PDF output by configuring PdfDevice.AnyPage before rendering.

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
            // Load the HTML document
            HTMLDocument document = new HTMLDocument("input.html");

            // Configure PDF rendering options with a custom page size of 600x800 pixels
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 800));

            // Create a PDF device with the configured options and specify the output file
            PdfDevice device = new PdfDevice(options, "output.pdf");

            // Render the HTML document to the PDF device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}