// Create a PdfDevice with custom page size of 5 by 7 inches for small‑format PDF generation.

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
            // Create rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Set custom page size: 5 inches x 7 inches (assuming 96 DPI)
            int width = (int)(5 * 96);   // 480 pixels
            int height = (int)(7 * 96);  // 672 pixels
            options.PageSetup.AnyPage = new Page(new Size(width, height));

            // Initialize PdfDevice with the configured options and output file path
            using (PdfDevice device = new PdfDevice(options, "small_format.pdf"))
            {
                // Device is ready for rendering operations
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}