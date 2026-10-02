// Create a function that accepts a CSS selector and returns the inner text of the first matching element.

class Program
{
    static void Main()
    {
        try
        {
            string selector = "p.intro";
            string result = GetInnerText(selector);
            System.Console.WriteLine("Inner text: " + result);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string GetInnerText(string selector)
    {
        string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><p class='intro'>Hello World</p><div>Other</div></body></html>";
        string baseUri = "about:blank";
        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
        Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll(selector);
        foreach (Aspose.Html.HTMLElement element in elements)
        {
            return element.TextContent;
        }
        return string.Empty;
    }
}