// Apply a custom NodeFilter to extract only script tags while ignoring other elements.

using System;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyScriptFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        return string.Equals("script", n.LocalName, StringComparison.OrdinalIgnoreCase) ? FILTER_ACCEPT : FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script src='script1.js'></script></head><body><script>console.log('test');</script><div>content</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            ITreeWalker iterator = document.CreateTreeWalker(document, NodeFilter.SHOW_ALL, new OnlyScriptFilter());

            while (iterator.NextNode() != null)
            {
                Element scriptElement = (Element)iterator.CurrentNode;
                Console.WriteLine(scriptElement.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}