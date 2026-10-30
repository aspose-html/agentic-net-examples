// Use MutationObserver to detect canvas element changes, then trigger automatic PDF regeneration.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 300;
            document.Body.AppendChild(canvas);

            // Create a script element with MutationObserver logic
            Aspose.Html.HTMLElement script = (Aspose.Html.HTMLElement)document.CreateElement("script");
            script.InnerHTML = @"
                var canvas = document.querySelector('canvas');
                var observer = new MutationObserver(function(mutations) {
                    console.log('Canvas mutated');
                });
                observer.observe(canvas, { attributes: true, childList: true, subtree: true });

                // Change canvas after a short delay
                setTimeout(function() {
                    var ctx = canvas.getContext('2d');
                    ctx.fillStyle = 'green';
                    ctx.fillRect(50, 50, 200, 150);
                }, 500);
            ";
            document.Body.AppendChild(script);

            // Render the document to PDF
            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, "output.pdf");
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}