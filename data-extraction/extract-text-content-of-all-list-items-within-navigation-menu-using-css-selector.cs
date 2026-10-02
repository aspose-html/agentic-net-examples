// Extract the text content of all list items within a navigation menu using a CSS selector.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><nav><ul><li>Home</li><li>About</li><li>Contact</li></ul></nav></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                var items = document.QuerySelectorAll("nav li");
                foreach (Aspose.Html.HTMLElement item in items)
                {
                    string text = item.TextContent != null ? item.TextContent.Trim() : string.Empty;
                    Console.WriteLine(text);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}