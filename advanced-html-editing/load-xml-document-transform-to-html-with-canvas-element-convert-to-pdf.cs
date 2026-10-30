// Load an XML document, transform it to HTML with a canvas element, and convert to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample XML file
            string xmlPath = "sample.xml";
            if (!File.Exists(xmlPath))
            {
                string sampleXml = "<root><message>Hello, World!</message></root>";
                File.WriteAllText(xmlPath, sampleXml);
            }

            // Load XML content
            string xmlContent = File.ReadAllText(xmlPath);

            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Embed XML content into HTML for demonstration
            Aspose.Html.HTMLElement pre = (Aspose.Html.HTMLElement)document.CreateElement("pre");
            pre.InnerHTML = xmlContent;
            document.Body.AppendChild(pre);

            // Create canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create linear gradient
            Aspose.Html.Dom.Canvas.ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");

            // Apply gradient and draw
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;
            context.FillText("Canvas Text", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            // Convert to PDF
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}