// Create a CSS rule using -aspose- page‑margin to add printable margins around canvas content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            // Create an empty HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Create style element and add CSS rule with -aspose-page-margin
            var styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.InnerHTML = "@page { -aspose-page-margin: 10mm; }";
            document.Body.AppendChild(styleElement);

            // Create canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 800;
            canvas.Height = 600;
            document.Body.AppendChild(canvas);

            // Render the document to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
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