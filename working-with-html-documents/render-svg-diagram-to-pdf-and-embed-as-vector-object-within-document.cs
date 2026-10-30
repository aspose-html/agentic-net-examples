// Render an SVG diagram to a PDF and embed it as a vector object within the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\">" +
                                "<rect x=\"10\" y=\"10\" width=\"180\" height=\"180\" fill=\"lightblue\" stroke=\"navy\" stroke-width=\"4\"/>" +
                                "<circle cx=\"100\" cy=\"100\" r=\"60\" fill=\"orange\"/>" +
                                "</svg>";
            string svgPath = "sample.svg";
            File.WriteAllText(svgPath, svgContent);

            // Load SVG document
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Set up PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

            // Create PDF device
            string pdfPath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, pdfPath);

            // Render SVG to PDF
            Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();
            renderer.Render(pdfDevice, svgDoc);

            // Clean up temporary SVG file
            File.Delete(svgPath);

            Console.WriteLine("SVG has been successfully rendered to PDF: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}