// Perform incremental conversion of large HTML files to PDF by processing sections with separate PdfDevice instances.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.pdf";

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            string html1 = "<html><body><h1>Section 1</h1><p>Content of first section.</p></body></html>";
            string html2 = "<html><body><h1>Section 2</h1><p>Content of second section.</p></body></html>";
            string html3 = "<html><body><h1>Section 3</h1><p>Content of third section.</p></body></html>";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, "");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, "");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, "");

            renderer.Render(device, document1, document2, document3);

            Console.WriteLine("PDF generated at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}