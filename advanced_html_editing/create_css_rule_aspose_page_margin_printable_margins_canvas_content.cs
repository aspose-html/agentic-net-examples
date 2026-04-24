// Create a CSS rule using -aspose- page‑margin to add printable margins around canvas content.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            HTMLDocument document = new HTMLDocument();

            Element style = document.CreateElement("style");
            style.InnerHTML = "html { -aspose-page-margin: 20mm; }";
            document.Body.AppendChild(style);

            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 400;
            document.Body.AppendChild(canvas);

            using (PdfDevice device = new PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}