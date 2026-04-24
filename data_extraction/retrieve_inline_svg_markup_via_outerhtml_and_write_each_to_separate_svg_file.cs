// Retrieve inline SVG markup via OuterHTML and write each to a separate .svg file.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            HTMLDocument document = new HTMLDocument(htmlPath);
            HTMLCollection svgs = document.GetElementsByTagName("svg");
            for (int i = 0; i < svgs.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                string fileName = $"svg_{i}.svg";
                SVGDocument svgDoc = new SVGDocument(markup, "");
                svgDoc.Save(fileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}