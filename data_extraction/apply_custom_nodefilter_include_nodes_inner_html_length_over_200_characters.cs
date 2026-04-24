// Apply a custom NodeFilter that includes only nodes whose inner HTML length exceeds 200 characters.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class LongContentFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        var element = n as HTMLElement;
        if (element != null && element.InnerHTML != null && element.InnerHTML.Length > 200)
            return FILTER_ACCEPT;
        return FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>
                <div>" + new string('a', 250) + @"</div>
                <p>" + new string('b', 150) + @"</p>
                <section>" + new string('c', 300) + @"</section>
                </body></html>";
            string baseUri = "http://example.com";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            ITreeWalker walker = document.CreateTreeWalker(document, NodeFilter.SHOW_ELEMENT, new LongContentFilter());

            while (walker.NextNode() != null)
            {
                var element = walker.CurrentNode as HTMLElement;
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