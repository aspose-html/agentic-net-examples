// Extract the content attribute of all meta tags that specify viewport settings via CSS selector.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"><meta name=\"viewport\" content=\"width=500\"><meta charset=\"utf-8\"></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("meta[name='viewport']");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string content = element.GetAttribute("content");
                System.Console.WriteLine(content);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}