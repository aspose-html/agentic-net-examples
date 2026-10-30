// Create a CSS rule using -aspose- page‑margin to add printable margins around canvas content.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            // Create an empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Create style element using valid Element type
            Element style = document.CreateElement("style");
            ((HTMLElement)style).InnerHTML = "canvas { -aspose-page-margin: 10mm; }";

            // Append style safely (DO NOT use document.Head)
            document.Body.AppendChild(style);

            // Create canvas
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 400;

            document.Body.AppendChild(canvas);

            // Render to PDF
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