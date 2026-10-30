// Create a CSS -aspose- rule that adds a background color to all canvas elements in the PDF.

class Program
{
    static void Main()
    {
        try
        {
            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a style element with CSS rule for canvas background
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "canvas { background-color: #FFCC00; }";
            document.Body.AppendChild(style);

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 300;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Render the document to PDF
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("PDF generated at " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}