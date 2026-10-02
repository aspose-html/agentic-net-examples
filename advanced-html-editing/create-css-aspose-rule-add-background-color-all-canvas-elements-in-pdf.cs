// Create a CSS -aspose- rule that adds a background color to all canvas elements in the PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a style element and add CSS rule for canvas background color
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "canvas { background-color: #FF0000; }";

            // Append the style to the document body
            document.Body.AppendChild(style);

            // Define output PDF path
            string outputPath = "output.pdf";

            // Render the document to PDF
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