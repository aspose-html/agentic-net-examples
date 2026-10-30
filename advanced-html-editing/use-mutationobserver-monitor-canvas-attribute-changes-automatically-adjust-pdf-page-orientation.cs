// Use MutationObserver to monitor attribute changes on canvas and automatically adjust PDF page orientation.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 400;
            document.Body.AppendChild(canvas);

            // Create a script element with MutationObserver logic
            Aspose.Html.HTMLElement script = (Aspose.Html.HTMLElement)document.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.InnerHTML = @"
                var canvas = document.querySelector('canvas');
                var observer = new MutationObserver(function(mutations) {
                    mutations.forEach(function(m) {
                        if (m.attributeName === 'width' || m.attributeName === 'height') {
                            // Placeholder: adjust PDF orientation here based on new size
                            console.log('Canvas size changed: ' + canvas.getAttribute('width') + 'x' + canvas.getAttribute('height'));
                        }
                    });
                });
                observer.observe(canvas, { attributes: true });

                // Change canvas attributes after a short delay to trigger the observer
                setTimeout(function() {
                    canvas.setAttribute('width', '800');
                    canvas.setAttribute('height', '600');
                }, 1000);
            ";
            document.Body.AppendChild(script);

            // Render the document to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}