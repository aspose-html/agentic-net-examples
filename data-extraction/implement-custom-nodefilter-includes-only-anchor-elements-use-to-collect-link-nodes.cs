// Implement a custom NodeFilter that includes only anchor elements and use it to collect link nodes.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><a href=\"https://example.com\">Example</a><p>Paragraph</p><a href=\"https://test.com\">Test</a></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Dom.Traversal.ITreeWalker walker = document.CreateTreeWalker(document, Aspose.Html.Dom.Traversal.Filters.NodeFilter.SHOW_ALL, new OnlyAnchorFilter());
                System.Collections.Generic.List<string> links = new System.Collections.Generic.List<string>();
                while (walker.NextNode() != null)
                {
                    Aspose.Html.Dom.Node current = walker.CurrentNode;
                    if (current is Aspose.Html.HTMLAnchorElement anchor)
                    {
                        string href = anchor.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            links.Add(href);
                        }
                    }
                }
                System.Console.WriteLine("Collected links:");
                foreach (string link in links)
                {
                    System.Console.WriteLine(link);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class OnlyAnchorFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
{
    public override short AcceptNode(Aspose.Html.Dom.Node n)
    {
        return string.Equals("a", n.LocalName, System.StringComparison.OrdinalIgnoreCase) ?
            Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_ACCEPT :
            Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_SKIP;
    }
}