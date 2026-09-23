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

            // Create HTML document
            HTMLDocument document = new HTMLDocument();

            // Create style element and add CSS rule for printable margins
            HTMLElement style = (HTMLElement)document.CreateElement("style");
            style.InnerHTML = "canvas { -aspose-page-margin: 10mm; }";
            document.Body.AppendChild(style);

            // Create canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 800;
            canvas.Height = 600;
            document.Body.AppendChild(canvas);

            // Render document to PDF
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}