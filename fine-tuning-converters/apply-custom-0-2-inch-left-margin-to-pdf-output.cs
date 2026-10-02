// Apply a custom 0.2‑inch left margin to PDF output by setting PdfRenderingOptions.MarginLeft.

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
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            var document = new Aspose.Html.HTMLDocument(htmlPath);

            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.2), // left
                Aspose.Html.Drawing.Length.FromInches(0.0), // top
                Aspose.Html.Drawing.Length.FromInches(0.0), // right
                Aspose.Html.Drawing.Length.FromInches(0.0)  // bottom
            );

            var size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points

            var page = new Aspose.Html.Drawing.Page(size, margin);

            options.PageSetup.AnyPage = page;

            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);

            document.RenderTo(device);

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}