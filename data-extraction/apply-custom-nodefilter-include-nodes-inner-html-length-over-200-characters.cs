// Apply a custom NodeFilter that includes only nodes whose inner HTML length exceeds 200 characters.

using System;

class OnlyLongContentFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
{
    public override short AcceptNode(Aspose.Html.Dom.Node n)
    {
        Aspose.Html.HTMLElement element = n as Aspose.Html.HTMLElement;
        if (element != null && element.InnerHTML != null && element.InnerHTML.Length > 200)
        {
            return Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_ACCEPT;
        }
        return Aspose.Html.Dom.Traversal.Filters.NodeFilter.FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" + new string('a', 250) + "</body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Traversal.ITreeWalker iterator = document.CreateTreeWalker(
                document,
                Aspose.Html.Dom.Traversal.Filters.NodeFilter.SHOW_ALL,
                new OnlyLongContentFilter());

            while (iterator.NextNode() != null)
            {
                Aspose.Html.HTMLElement element = iterator.CurrentNode as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    Console.WriteLine($"Node <{element.LocalName}> InnerHTML length: {element.InnerHTML.Length}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}