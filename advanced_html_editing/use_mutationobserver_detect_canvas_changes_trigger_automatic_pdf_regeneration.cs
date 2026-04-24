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
            string outputPath = "output.pdf";

            HTMLDocument document = new HTMLDocument();

            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);

            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "green";
            context.FillRect(50, 50, 300, 100);

            var script = document.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.InnerHTML = @"
var canvas = document.querySelector('canvas');
var observer = new MutationObserver(function(mutations) {
    console.log('Canvas mutated');
});
observer.observe(canvas, { attributes: true, childList: true, subtree: true });
";
            document.Body.AppendChild(script);

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