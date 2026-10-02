// Save each extracted inline SVG markup to a .svg file preserving original markup.

using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/></svg><p>Text</p><svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' style='fill:blue'/></svg></body></html>";
                Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                for (int i = 0; i < svgs.Length; i++)
                {
                    Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                    string markup = svgElement.OuterHTML;
                    string fileName = $"{i}.svg";
                    Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                    svgDoc.Save(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}