// Render an SVG image to PDF by creating PdfDevice with AnyPage set to 600x500 pixels.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define file paths
                string svgPath = "sample.svg";
                string pdfPath = "output.pdf";

                // Create a minimal SVG file if it does not exist
                if (!System.IO.File.Exists(svgPath))
                {
                    string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"blue\"/></svg>";
                    System.IO.File.WriteAllText(svgPath, svgContent);
                }

                // Load the SVG document
                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

                // Initialize the SVG renderer
                Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();

                // Set up PDF rendering options with the desired page size
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 500));

                // Create the PDF device
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);

                // Render the SVG to PDF
                renderer.Render(device, document);

                System.Console.WriteLine("SVG successfully rendered to PDF: " + pdfPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}