// Extract each inline SVG's markup via the OuterHTML property.

using System;

namespace ExtractSvgExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/></svg><svg width='50' height='50'><rect width='50' height='50' style='fill:blue;'/></svg></body></html>";

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

                for (int i = 0; i < svgs.Length; i++)
                {
                    Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                    string markup = svgElement.OuterHTML;
                    string fileName = $"svg_{i}.svg";
                    Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                    svgDoc.Save(fileName);
                    Console.WriteLine($"Saved SVG #{i} to {fileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}