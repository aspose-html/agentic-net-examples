// Use MutationObserver to detect canvas element changes, then trigger automatic PDF regeneration.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

namespace AsposeHtmlMutationObserverExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create canvas element
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 600;
                canvas.Height = 400;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Initial drawing
                context.FillStyle = "lightblue";
                context.FillRect(0, 0, canvas.Width, canvas.Height);
                context.FillStyle = "darkblue";
                context.FillRect(50, 50, 200, 150);

                // Render initial PDF
                using (PdfDevice device = new PdfDevice("output_initial.pdf"))
                {
                    document.RenderTo(device);
                }

                // Simulate canvas change (e.g., modify drawing)
                context.FillStyle = "orange";
                context.FillRect(300, 200, 150, 100);

                // Render updated PDF
                using (PdfDevice device = new PdfDevice("output_updated.pdf"))
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
}