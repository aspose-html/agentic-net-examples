// Convert inline SVG elements to external files and replace them with <img> references.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><body><h1>Test</h1><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            HTMLDocument document = new HTMLDocument(htmlPath);
            Aspose.Html.Collections.NodeList svgElements = document.QuerySelectorAll("svg");

            for (int i = 0; i < svgElements.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgElements[i];
                string svgMarkup = svgElement.OuterHTML;
                string imagePath = $"image{i}.png";

                ImageSaveOptions options = new ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgMarkup, "about:blank", options, imagePath);

                Element imgElement = document.CreateElement("img");
                imgElement.SetAttribute("src", imagePath);

                svgElement.ParentNode.ReplaceChild(imgElement, svgElement);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}