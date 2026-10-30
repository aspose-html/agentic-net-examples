// Load an HTML file, edit its canvas graphics, and export the result to a PDF file.

public class Program
{
    public static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Create a canvas element and configure its size
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Obtain 2D rendering context
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create a linear gradient and add color stops
            var gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");

            // Apply gradient as fill and stroke styles
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            // Draw a filled rectangle covering the canvas
            context.FillRect(0, 0, canvas.Width, canvas.Height);

            // Render some text on the canvas
            context.FillText("Hello Canvas", 10, 50, 500);

            // Render the modified document to a PDF file
            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath);
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}