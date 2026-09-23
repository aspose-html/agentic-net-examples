// Extract each inline SVG's markup via the OuterHTML property.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a sample HTML file with inline SVGs
            string htmlPath = "sample.html";
            string htmlContent = "<html><body>" +
                                 "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg>" +
                                 "<svg width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" style=\"fill:blue;\"/></svg>" +
                                 "</body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all inline SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                string outputPath = $"svg_{i}.svg";

                // Create an SVG document from the markup and save it
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "");
                svgDoc.Save(outputPath);
            }

            System.Console.WriteLine("SVG extraction completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}