// Retrieve inline SVG markup via OuterHTML and write each to a separate .svg file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg>" +
                                 "<div>Some text</div>" +
                                 "<svg width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" style=\"fill:blue\"/></svg>" +
                                 "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                string fileName = $"svg_{i}.svg";

                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(fileName);
            }

            Console.WriteLine("SVG files saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}