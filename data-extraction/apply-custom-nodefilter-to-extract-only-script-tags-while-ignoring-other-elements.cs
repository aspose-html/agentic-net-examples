// Apply a custom NodeFilter to extract only script tags while ignoring other elements.

using System;

class OnlyScriptFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
{
    public override short AcceptNode(Aspose.Html.Dom.Node n)
    {
        return string.Equals("script", n.LocalName, StringComparison.OrdinalIgnoreCase)
            ? Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_ACCEPT
            : Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script src='a.js'></script></head><body><script>console.log('test');</script><div>content</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Traversal.ITreeWalker iterator = document.CreateTreeWalker(
                document,
                Aspose.Html.Dom.Traversal.Filters.NodeFilter.SHOW_ALL,
                new OnlyScriptFilter());

            while (iterator.NextNode() != null)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)iterator.CurrentNode;
                System.Console.WriteLine(scriptElement.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}