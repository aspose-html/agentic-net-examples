// Extract all anchor elements that open in a new window (target="_blank") for security review.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = @"
                <html>
                    <body>
                        <a href='https://example.com' target='_blank'>Example</a>
                        <a href='https://test.com'>Test</a>
                        <a href='https://open.com' target='_blank'>Open</a>
                    </body>
                </html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");
                List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element link = (Aspose.Html.Dom.Element)links[i];
                    string target = link.GetAttribute("target");
                    if (string.Equals(target, "_blank", StringComparison.OrdinalIgnoreCase))
                    {
                        string href = link.GetAttribute("href");
                        string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                        if (!string.IsNullOrEmpty(href))
                        {
                            var item = new Dictionary<string, string>
                            {
                                { "href", href },
                                { "text", text }
                            };
                            result.Add(item);
                        }
                    }
                }

                foreach (var item in result)
                {
                    Console.WriteLine($"Href: {item["href"]}, Text: {item["text"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}