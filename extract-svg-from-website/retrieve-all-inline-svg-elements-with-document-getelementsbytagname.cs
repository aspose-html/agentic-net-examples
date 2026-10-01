// Retrieve all inline <svg> elements with document.GetElementsByTagName("svg").

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<h1>Sample</h1>" +
                                 "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>" +
                                 "<p>Text</p>" +
                                 "<svg width=\"50\" height=\"50\"><rect width=\"50\" height=\"50\" style=\"fill:blue;\"/></svg>" +
                                 "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                Console.WriteLine($"SVG #{i}:");
                Console.WriteLine(markup);
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}