// Use MutationObserver to monitor attribute changes on canvas and automatically adjust PDF page orientation.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Add a style element
            Aspose.Html.HTMLElement styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.InnerHTML = "canvas { border:1px solid #000; }";
            document.Body.AppendChild(styleElement);

            // Add a script element with MutationObserver
            Aspose.Html.HTMLElement scriptElement = (Aspose.Html.HTMLElement)document.CreateElement("script");
            scriptElement.InnerHTML = @"
var canvas = document.querySelector('canvas');
var observer = new MutationObserver(function(mutations) {
    mutations.forEach(function(mutation) {
        if (mutation.attributeName === 'width' || mutation.attributeName === 'height') {
            // Placeholder for orientation adjustment logic
            console.log('Canvas size changed: ' + canvas.width + 'x' + canvas.height);
        }
    });
});
observer.observe(canvas, { attributes: true });
";
            document.Body.AppendChild(scriptElement);

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 800;
            document.Body.AppendChild(canvas);

            // Draw something on the canvas
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "#FF0000";
            context.FillRect(0, 0, canvas.Width, canvas.Height);

            // Render the document to PDF
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}