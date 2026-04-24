// Use MutationObserver to monitor attribute changes on canvas and automatically adjust PDF page orientation.

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
            // Output PDF file path
            string outputPath = "canvas_observer.pdf";

            // Create an empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a canvas element and set its size
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 300;
            document.Body.AppendChild(canvas);

            // Insert a script that uses MutationObserver to watch canvas attribute changes
            Element script = document.CreateElement("script");
            script.InnerHTML = @"
                var canvas = document.getElementsByTagName('canvas')[0];
                var observer = new MutationObserver(function(mutations) {
                    mutations.forEach(function(mutation) {
                        if (mutation.attributeName === 'width' || mutation.attributeName === 'height') {
                            // Adjust page orientation based on canvas dimensions
                            var orientation = canvas.width > canvas.height ? 'landscape' : 'portrait';
                            document.body.setAttribute('data-orientation', orientation);
                        }
                    });
                });
                observer.observe(canvas, { attributes: true });
                // Example change to trigger the observer
                setTimeout(function(){ canvas.setAttribute('width', '800'); }, 1000);
            ";
            document.Body.AppendChild(script);

            // Render the HTML document (including the script execution) to a PDF file
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