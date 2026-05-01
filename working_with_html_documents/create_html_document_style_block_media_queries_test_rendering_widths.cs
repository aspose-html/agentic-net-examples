// Create an HTML document, add a style block with media queries, and test rendering on different widths.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering.Pdf;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "output.pdf";

                // Create a new HTML document
                HTMLDocument document = new HTMLDocument();

                // Create a style element with media queries
                Element style = document.CreateElement("style");
                style.InnerHTML = "@media (max-width: 600px) { body { background-color: lightblue; } } @media (min-width: 601px) { body { background-color: lightgreen; } }";

                // Append the style to the document body
                document.Body.AppendChild(style);

                // Add sample content to visualize the media query effect
                Element div = document.CreateElement("div");
                div.SetAttribute("style", "padding:20px; font-size:24px;");
                div.TextContent = "Responsive Design Test";
                document.Body.AppendChild(div);

                // Render the document to PDF
                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine("HTML document rendered to PDF successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}