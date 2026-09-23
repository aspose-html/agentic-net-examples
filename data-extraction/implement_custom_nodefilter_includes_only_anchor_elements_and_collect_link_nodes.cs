// Implement a custom NodeFilter that includes only anchor elements and use it to collect link nodes.

using System;
using System.Collections.Generic;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyAnchorFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        if (n is Element element && string.Equals("a", element.LocalName, StringComparison.OrdinalIgnoreCase))
            return FILTER_ACCEPT;
        return FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href='https://example.com'>Example</a>" +
                                 "<p>Paragraph</p>" +
                                 "<a href='https://test.com'>Test</a>" +
                                 "</body></html>";

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, ""))
            {
                var walker = document.CreateTreeWalker(
                    document,
                    NodeFilter.SHOW_ALL,
                    new OnlyAnchorFilter());

                var links = new List<Dictionary<string, string>>();

                while (walker.NextNode() != null)
                {
                    var element = walker.CurrentNode as Element;
                    if (element != null)
                    {
                        string href = element.GetAttribute("href");
                        string text = element.TextContent?.Trim() ?? string.Empty;
                        if (!string.IsNullOrEmpty(href))
                        {
                            var dict = new Dictionary<string, string>
                            {
                                { "href", href },
                                { "text", text }
                            };
                            links.Add(dict);
                        }
                    }
                }

                foreach (var link in links)
                {
                    Console.WriteLine($"Href: {link["href"]}, Text: {link["text"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}