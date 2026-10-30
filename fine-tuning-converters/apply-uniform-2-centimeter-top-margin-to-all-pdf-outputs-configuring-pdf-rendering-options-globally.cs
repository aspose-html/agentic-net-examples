// Apply a uniform 2‑centimeter top margin to all PDF outputs by configuring PdfRenderingOptions globally.

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

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromCentimeters(2), // top
                Aspose.Html.Drawing.Length.FromCentimeters(0), // right
                Aspose.Html.Drawing.Length.FromCentimeters(0), // bottom
                Aspose.Html.Drawing.Length.FromCentimeters(0)  // left
            );

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8),
                Aspose.Html.Drawing.Length.FromInches(11)
            );

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}