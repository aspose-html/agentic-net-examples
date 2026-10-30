// Filter DOM nodes to include only elements with a data-id attribute using a custom NodeFilter.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyDataIdFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        if (n.NodeType == Node.ELEMENT_NODE)
        {
            Element element = (Element)n;
            string attr = element.GetAttribute("data-id");
            if (!string.IsNullOrEmpty(attr))
            {
                return FILTER_ACCEPT;
            }
        }
        return FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<div data-id='1'>First</div>" +
                          "<p>No ID</p>" +
                          "<span data-id='2'>Second</span>" +
                          "</body></html>";

            HTMLDocument document = new HTMLDocument(html, "about:blank");

            ITreeWalker walker = document.CreateTreeWalker(
                document,
                NodeFilter.SHOW_ALL,
                new OnlyDataIdFilter()
            );

            while (walker.NextNode() != null)
            {
                Node current = walker.CurrentNode;
                Element element = (Element)current;
                Console.WriteLine($"Tag: {element.LocalName}, data-id: {element.GetAttribute("data-id")}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}