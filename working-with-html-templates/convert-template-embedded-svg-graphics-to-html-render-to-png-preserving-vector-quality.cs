// Convert a template with embedded SVG graphics to HTML and render it to PNG preserving vector quality.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with embedded SVG
            string htmlContent = @"
                <html>
                <body>
                    <h1>Sample Document</h1>
                    <svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
                        <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
                    </svg>
                </body>
                </html>";

            // Load HTML document from string (use two‑argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all SVG elements
            Aspose.Html.Collections.NodeList svgElements = document.QuerySelectorAll("svg");

            for (int i = 0; i < svgElements.Length; i++)
            {
                // Cast to HTMLElement to access OuterHTML
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgElements[i];
                string svgMarkup = svgElement.OuterHTML;

                // Define output PNG path for this SVG
                string imagePath = $"svg_{i}.png";

                // Set image save options (high resolution, antialiasing)
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.UseAntialiasing = true;

                // Convert SVG markup to PNG file
                Aspose.Html.Converters.Converter.ConvertSVG(svgMarkup, "svg", options, imagePath);

                // Create <img> element and set src attribute
                Aspose.Html.Dom.Element imgElement = document.CreateElement("img");
                imgElement.SetAttribute("src", imagePath);
                imgElement.SetAttribute("width", "100");
                imgElement.SetAttribute("height", "100");

                // Replace SVG with the generated image
                svgElement.ParentNode.ReplaceChild(imgElement, svgElement);
            }

            // Save the resulting HTML document
            string outputHtmlPath = "output.html";
            document.Save(outputHtmlPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}