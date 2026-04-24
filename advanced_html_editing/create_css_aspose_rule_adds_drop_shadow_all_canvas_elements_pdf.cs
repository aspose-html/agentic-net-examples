// Create a CSS -aspose- rule that adds a drop shadow to all canvas elements in PDF.

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

            // Create style element using valid Element type
            Element style = document.CreateElement("style");
            style.InnerHTML = "canvas { filter: drop-shadow(5px 5px 5px rgba(0,0,0,0.5)); }";

            // Append style safely (DO NOT use document.Head)
            document.Body.AppendChild(style);

            // Create canvas
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);

            // Render to PDF
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}