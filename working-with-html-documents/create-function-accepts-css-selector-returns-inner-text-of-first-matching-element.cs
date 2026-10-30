// Create a function that accepts a CSS selector and returns the inner text of the first matching element.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string selector = ".test";
            string result = GetInnerText(selector);
            System.Console.WriteLine($"Inner text of first element matching \"{selector}\": {result}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string GetInnerText(string selector)
    {
        string html = "<html><body><div class='test'>Hello <span>World</span></div><p>Paragraph</p></body></html>";
        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
        Aspose.Html.Dom.Element element = document.QuerySelector(selector);
        return element != null ? element.TextContent : string.Empty;
    }
}