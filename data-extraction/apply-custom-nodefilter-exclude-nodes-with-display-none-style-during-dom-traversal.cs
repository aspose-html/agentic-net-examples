// Apply a custom NodeFilter that excludes nodes with display:none style during DOM traversal.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><div style='display:none'>Hidden</div><p>Visible</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var filter = new OnlyVisibleFilter();
            var walker = document.CreateTreeWalker(document, Aspose.Html.Dom.Traversal.Filters.NodeFilter.SHOW_ELEMENT, filter);
            Aspose.Html.Dom.Node node;
            while ((node = walker.NextNode()) != null)
            {
                Console.WriteLine(node.NodeName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class OnlyVisibleFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
{
    public override short AcceptNode(Aspose.Html.Dom.Node n)
    {
        if (n.NodeType == Aspose.Html.Dom.Node.ELEMENT_NODE)
        {
            var element = (Aspose.Html.Dom.Element)n;
            var style = element.GetAttribute("style");
            if (!string.IsNullOrEmpty(style) && style.IndexOf("display:none", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_SKIP;
            }
        }
        return Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_ACCEPT;
    }
}