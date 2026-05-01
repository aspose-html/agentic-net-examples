// Convert 500 pixel height to millimeters and use the result to set image height in PDF.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 500 pixels to millimeters (96 DPI)
            double pixels = 500;
            const double ppi = 96.0;
            double heightMillimeters = (pixels / ppi) * 25.4;

            // Create a simple HTML document
            HTMLDocument document = new HTMLDocument("<html><body><h1>Hello World</h1></body></html>");

            // Prepare PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Set page size: width 210 mm (A4 width), height from conversion
            Page page = new Page(new Size(Length.FromMillimeters(210), Length.FromMillimeters(heightMillimeters)));
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF with the specified page height
            Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}