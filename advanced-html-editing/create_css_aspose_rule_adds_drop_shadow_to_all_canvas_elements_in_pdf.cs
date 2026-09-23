// Create a CSS -aspose- rule that adds a drop shadow to all canvas elements in PDF.

using System;

namespace AsposeHtmlCssShadowExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputPath = "output.pdf";

                var document = new Aspose.Html.HTMLDocument();

                var style = (Aspose.Html.HTMLElement)document.CreateElement("style");
                style.InnerHTML = "canvas { filter: drop-shadow(5px 5px 5px rgba(0,0,0,0.5)); }";
                document.Body.AppendChild(style);

                var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 200;
                canvas.Height = 100;
                document.Body.AppendChild(canvas);

                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine("PDF generated at " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}