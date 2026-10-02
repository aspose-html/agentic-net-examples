// Extract each inline SVG's markup via the OuterHTML property.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<svg width='100' height='100'>" +
                                 "<circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/>" +
                                 "</svg>" +
                                 "<p>Sample paragraph.</p>" +
                                 "<svg xmlns='http://www.w3.org/2000/svg' width='50' height='50'>" +
                                 "<rect width='50' height='50' style='fill:blue;'/>" +
                                 "</svg>" +
                                 "</body></html>";

            // Load HTML from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all inline SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                System.Console.WriteLine($"--- SVG {i} markup ---");
                System.Console.WriteLine(markup);
                System.Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}