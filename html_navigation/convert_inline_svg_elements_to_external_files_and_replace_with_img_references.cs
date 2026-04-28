// Convert inline SVG elements to external files and replace them with <img> references.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(htmlPath);
            var svgElements = document.QuerySelectorAll("svg");

            for (int i = 0; i < svgElements.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgElements[i];
                string svgMarkup = svgElement.OuterHTML;
                string imagePath = $"image{i}.png";

                ImageSaveOptions options = new ImageSaveOptions();
                Converter.ConvertSVG(svgMarkup, ".", options, imagePath);

                Element imgElement = document.CreateElement("img");
                imgElement.SetAttribute("src", imagePath);
                svgElement.ParentNode.ReplaceChild(imgElement, svgElement);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}