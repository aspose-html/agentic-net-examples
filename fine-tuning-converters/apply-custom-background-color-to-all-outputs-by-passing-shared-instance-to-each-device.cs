// Apply a custom background color to all outputs by passing a shared RenderingOptions instance to each device.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>Document 1</h1></body></html>";
            string html2 = "<html><body><h1>Document 2</h1></body></html>";
            string html3 = "<html><body><h1>Document 3</h1></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.BackgroundColor = Color.AliceBlue;

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize);
            options.PageSetup.AnyPage = page;

            string outputPath1 = "output1.pdf";
            string outputPath2 = "output2.pdf";
            string outputPath3 = "output3.pdf";

            Aspose.Html.Rendering.Pdf.PdfDevice device1 = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath1);
            Aspose.Html.Rendering.Pdf.PdfDevice device2 = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath2);
            Aspose.Html.Rendering.Pdf.PdfDevice device3 = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath3);

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            renderer.Render(device1, document1);
            renderer.Render(device2, document2);
            renderer.Render(device3, document3);

            Console.WriteLine("PDF files generated with custom background color.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}