// Load an XML document, transform it to HTML with a canvas element, and convert to PDF.

using System;
using System.IO;
using System.Xml;

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
                string sampleXml = "<root><title>Hello World from XML</title></root>";
                File.WriteAllText(xmlPath, sampleXml);
            }

            // Load XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            string title = xmlDoc.SelectSingleNode("//title")?.InnerText ?? "Default Title";

            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Add heading with XML data
            Aspose.Html.HTMLElement heading = (Aspose.Html.HTMLElement)document.CreateElement("h1");
            heading.InnerHTML = title;
            document.Body.AppendChild(heading);

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

            // Render to PDF
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