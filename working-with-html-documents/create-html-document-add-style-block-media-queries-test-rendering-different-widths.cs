// Create an HTML document, add a style block with media queries, and test rendering on different widths.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create style element with media queries
            Aspose.Html.Dom.Element styleElem = document.CreateElement("style");
            Aspose.Html.HTMLElement styleHtml = (Aspose.Html.HTMLElement)styleElem;
            styleHtml.InnerHTML = "@media (max-width: 400px) { .box { background: red; } } @media (min-width: 401px) { .box { background: green; } }";

            document.Body.AppendChild(styleHtml);

            // Add a div to demonstrate responsive styling
            Aspose.Html.Dom.Element div = document.CreateElement("div");
            div.SetAttribute("class", "box");
            div.TextContent = "Responsive Box";
            document.Body.AppendChild(div);

            // Render to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}