// Create a CSS -aspose- rule that adds a drop shadow to all canvas elements in PDF.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Output PDF path
            string outputPath = "output.pdf";

            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a style element with CSS rule for canvas drop shadow
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "canvas { filter: drop-shadow(5px 5px 5px rgba(0,0,0,0.5)); }";
            document.Body.AppendChild(style);

            // Create a canvas element (optional, to demonstrate the style)
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 300;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);

            // Render the document to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}