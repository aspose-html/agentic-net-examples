// Use MutationObserver to monitor attribute changes on canvas and automatically adjust PDF page orientation.

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

            // Get 2D rendering context and draw something
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "lightgray";
            context.FillRect(0, 0, canvas.Width, canvas.Height);
            context.FillStyle = "black";
            context.FillText("Canvas Content", 20, 50);

            // Render the document (including the canvas) to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}