// Load an EPUB file, locate its canvas element, draw text, and export the page as PDF.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

            // Load EPUB file as an HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 800;

            // Get 2D rendering context and draw text
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillText("Hello, EPUB Canvas!", 50, 100);

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Set up PDF save options
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Create PDF device for rendering
            var pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath);

            // Render the modified document to PDF
            document.RenderTo(pdfDevice);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}