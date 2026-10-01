// Use MutationObserver to detect canvas element changes, then trigger automatic PDF regeneration.

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
            canvas.Width = 500;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw a linear gradient on the canvas
            Aspose.Html.Dom.Canvas.ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");
            context.FillStyle = gradient;
            context.FillRect(0, 0, canvas.Width, canvas.Height);

            // Render the document (including the canvas) to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("PDF generated at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}