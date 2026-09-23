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
        if (n is Element element && element.HasAttribute("data-id"))
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
            string htmlContent = @"
                <html>
                    <body>
                        <div data-id='1'>First</div>
                        <p>No data-id here</p>
                        <span data-id='2'>Second</span>
                        <section>Another without attribute</section>
                    </body>
                </html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "");

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