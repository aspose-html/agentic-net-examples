// Apply a custom NodeFilter that includes only nodes whose inner HTML length exceeds 200 characters.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class OnlyLongContentFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        HTMLElement element = n as HTMLElement;
        if (element != null && element.InnerHTML != null && element.InnerHTML.Length > 200)
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
            string html = @"
                <html>
                    <body>
                        <div>Short content.</div>
                        <div>" + new string('A', 250) + @"</div>
                        <p>" + new string('B', 210) + @"</p>
                        <span>Another short one.</span>
                    </body>
                </html>";

            HTMLDocument document = new HTMLDocument(html, "about:blank");

            ITreeWalker walker = document.CreateTreeWalker(
                document,
                NodeFilter.SHOW_ALL,
                new OnlyLongContentFilter()
            );

            while (walker.NextNode() != null)
            {
                HTMLElement element = walker.CurrentNode as HTMLElement;
                if (element != null)
                {
                    Console.WriteLine(element.OuterHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}