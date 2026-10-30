// Apply a custom background color to all outputs by passing a shared RenderingOptions instance to each device.

using System;
using System.Drawing;

public class Program
{
    public static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h1>Second Document</h1></body></html>";
            string baseUri = "http://example.com/";
            string outputPath1 = "output1.pdf";
            string outputPath2 = "output2.pdf";

            var document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            var document2 = new Aspose.Html.HTMLDocument(html2, baseUri);

            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            var device1 = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath1);
            var device2 = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath2);

            var renderer = new Aspose.Html.Rendering.HtmlRenderer();

            renderer.Render(device1, document1);
            renderer.Render(device2, document2);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}