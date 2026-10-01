// Create an HTML document, add a style block with media queries, and test rendering on different widths.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a style element with media queries
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "@media (max-width: 600px) { .box { background-color: lightblue; } } @media (min-width: 601px) { .box { background-color: lightgreen; } }";

            // Append the style to the document body
            document.Body.AppendChild(style);

            // Create a div element that will be styled by the media queries
            Aspose.Html.Dom.Element div = document.CreateElement("div");
            div.SetAttribute("class", "box");
            div.TextContent = "Responsive Box";

            // Append the div to the document body
            document.Body.AppendChild(div);

            // Render the document to PDF to test the media queries at different widths
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("HTML document rendered to PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}