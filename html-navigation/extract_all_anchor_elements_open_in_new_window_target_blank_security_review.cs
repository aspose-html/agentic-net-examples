// Extract all anchor elements that open in a new window (target="_blank") for security review.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<a href='https://example.com' target='_blank'>Example</a>" +
                          "<a href='https://test.com'>Test</a>" +
                          "<a href='https://open.com' target='_blank'>Open</a>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html))
            {
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("a[target='_blank']");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    string href = element.GetAttribute("href");
                    string text = element.TextContent != null ? element.TextContent.Trim() : string.Empty;
                    if (!string.IsNullOrEmpty(href))
                    {
                        Console.WriteLine($"Href: {href}, Text: {text}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}