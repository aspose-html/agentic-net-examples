// Convert inline SVG elements to external files and replace them with <img> references.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with inline SVG if it does not exist
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>SVG Sample</title></head>
<body>
<h1>Inline SVG Example</h1>
<svg width=""100"" height=""100"" xmlns=""http://www.w3.org/2000/svg"">
  <circle cx=""50"" cy=""50"" r=""40"" stroke=""green"" stroke-width=""4"" fill=""yellow"" />
</svg>
<p>Another SVG:</p>
<svg width=""120"" height=""80"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""120"" height=""80"" style=""fill:blue;stroke:pink;stroke-width:5;opacity:0.5"" />
</svg>
</body>
</html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Find all inline SVG elements
            Aspose.Html.Collections.NodeList svgElements = document.QuerySelectorAll("svg");

            // Ensure output directory for images exists
            string imagesDir = "images";
            Directory.CreateDirectory(imagesDir);

            // Process each SVG element
            for (int i = 0; i < svgElements.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgElements[i];
                string svgMarkup = svgElement.OuterHTML;

                // Define image file path
                string imageFileName = $"image_{i + 1}.png";
                string imagePath = Path.Combine(imagesDir, imageFileName);

                // Convert SVG markup to PNG image
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgMarkup, "about:blank", options, imagePath);

                // Create <img> element referencing the saved image
                Aspose.Html.Dom.Element imgElement = document.CreateElement("img");
                imgElement.SetAttribute("src", imagePath);

                // Replace the original <svg> with the new <img>
                svgElement.ParentNode.ReplaceChild(imgElement, svgElement);
            }

            // Save the modified HTML document
            string outputHtmlPath = "result.html";
            document.Save(outputHtmlPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Modified HTML saved to: {outputHtmlPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}