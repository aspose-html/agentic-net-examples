// Implement a custom NodeFilter that includes only anchor elements and use it to collect link nodes.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyAnchorFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        return string.Equals("a", n.LocalName) ? FILTER_ACCEPT : FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href='https://example.com'>Example Site</a>" +
                                 "<p>Some paragraph.</p>" +
                                 "<a href='https://test.com'>Test Site</a>" +
                                 "</body></html>";

            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                ITreeWalker walker = document.CreateTreeWalker(
                    document,
                    NodeFilter.SHOW_ALL,
                    new OnlyAnchorFilter()
                );

                List<string> links = new List<string>();

                while (walker.NextNode() != null)
                {
                    Node current = walker.CurrentNode;
                    if (current is HTMLAnchorElement anchor)
                    {
                        string href = anchor.GetAttribute("href");
                        string text = anchor.TextContent != null ? anchor.TextContent.Trim() : string.Empty;
                        links.Add($"{href} - {text}");
                    }
                }

                Console.WriteLine("Collected anchor links:");
                foreach (string linkInfo in links)
                {
                    Console.WriteLine(linkInfo);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}