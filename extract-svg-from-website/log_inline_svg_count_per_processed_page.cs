// Log the count of inline SVGs found on each processed page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string[] htmlPages = new string[]
            {
                "<html><body><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg></body></html>",
                "<html><head></head><body><p>No SVG here</p></body></html>",
                "<html><body><svg></svg><svg></svg></body></html>"
            };

            for (int i = 0; i < htmlPages.Length; i++)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPages[i]);
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                System.Console.WriteLine($"Page {i + 1}: Found {svgs.Length} inline SVG(s).");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}