// Configure PdfRenderingOptions to set both top and bottom margins to 2 centimeters for uniform spacing.

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

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Convert centimeters to inches (1 cm = 0.393701 inches)
            double cmToInches = 0.393701;
            double marginInches = 2 * cmToInches; // 2 cm

            // IMPORTANT: margins must be defined via Margin object
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0),               // left
                Aspose.Html.Drawing.Length.FromInches(marginInches),   // top
                Aspose.Html.Drawing.Length.FromInches(0),               // right
                Aspose.Html.Drawing.Length.FromInches(marginInches)    // bottom
            );

            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

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