// Convert pixel dimensions to millimeters and use them to define printable area in PDF layout.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;

            // Convert pixels to millimeters (96 DPI, 25.4 mm per inch)
            const double ppi = 96.0;
            double widthMillimeters = widthPixels / ppi * 25.4;
            double heightMillimeters = heightPixels / ppi * 25.4;

            Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            Console.WriteLine($"Height: {heightMillimeters:F2} mm");

            // Configure PDF options with printable area based on the calculated size
            PdfSaveOptions options = new PdfSaveOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(
                    Length.FromMillimeters(widthMillimeters),
                    Length.FromMillimeters(heightMillimeters)));

            // Paths to source HTML and output PDF
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Convert HTML to PDF using the defined options
            Converter.ConvertHTML(htmlPath, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}