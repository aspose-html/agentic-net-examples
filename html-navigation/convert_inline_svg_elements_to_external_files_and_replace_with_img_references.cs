// Convert inline SVG elements to external files and replace them with <img> references.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with an inline SVG
            string htmlPath = "sample.html";
            string htmlContent = @"<html><body><h1>Sample</h1><svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' /></svg></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Find all inline SVG elements
            var svgElements = document.QuerySelectorAll("svg");

            // Process each SVG element
            for (int i = 0; i < svgElements.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgElements[i];
                string svgMarkup = svgElement.OuterHTML;

                // Define the external image file name
                string imagePath = $"image_{i}.png";

                // Convert SVG markup to PNG image
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgMarkup, ".", options, imagePath);

                // Create <img> element referencing the generated image
                Aspose.Html.Dom.Element imgElement = document.CreateElement("img");
                imgElement.SetAttribute("src", imagePath);

                // Replace the inline SVG with the <img> element
                svgElement.ParentNode.ReplaceChild(imgElement, svgElement);
            }

            // Save the modified HTML document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}