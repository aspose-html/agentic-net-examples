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
        Element element = n as Element;
        if (element != null && !string.IsNullOrEmpty(element.GetAttribute("data-id")))
        {
            return NodeFilter.FILTER_ACCEPT;
        }
        return NodeFilter.FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<div data-id=\"1\">First</div>" +
                                 "<p>No data-id</p>" +
                                 "<span data-id=\"2\">Second</span>" +
                                 "</body></html>";

            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            ITreeWalker walker = document.CreateTreeWalker(
                document,
                NodeFilter.SHOW_ELEMENT,
                new OnlyDataIdFilter()
            );

            while (walker.NextNode() != null)
            {
                Element current = (Element)walker.CurrentNode;
                System.Console.WriteLine(current.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}