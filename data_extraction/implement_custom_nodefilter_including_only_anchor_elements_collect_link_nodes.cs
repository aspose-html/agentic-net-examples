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
            string html = "<html><body><a href='https://example.com'>Example</a><p>Text</p><a href='https://test.com'>Test</a></body></html>";
            HTMLDocument document = new HTMLDocument(html, "");
            ITreeWalker walker = document.CreateTreeWalker(document, NodeFilter.SHOW_ALL, new OnlyAnchorFilter());
            List<HTMLAnchorElement> links = new List<HTMLAnchorElement>();
            while (walker.NextNode() != null)
            {
                HTMLAnchorElement anchor = walker.CurrentNode as HTMLAnchorElement;
                if (anchor != null)
                    links.Add(anchor);
            }
            foreach (var link in links)
            {
                Console.WriteLine($"{link.Href} - {link.TextContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}