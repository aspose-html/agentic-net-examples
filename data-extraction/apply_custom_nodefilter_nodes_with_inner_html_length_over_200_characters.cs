// Apply a custom NodeFilter that includes only nodes whose inner HTML length exceeds 200 characters.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with some long content
            string baseUrl = "";
            string htmlContent = @"
                <html>
                    <body>
                        <div>Short content.</div>
                        <div>" + new string('A', 250) + @"</div>
                        <p>" + new string('B', 210) + @"</p>
                        <span>Another short.</span>
                    </body>
                </html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(baseUrl, htmlContent);

            // Create a TreeWalker with the custom filter
            Aspose.Html.Dom.Traversal.ITreeWalker iterator = document.CreateTreeWalker(
                document,
                Aspose.Html.Dom.Traversal.Filters.NodeFilter.SHOW_ALL,
                new OnlyLongContentFilter()
            );

            // Iterate and output nodes that satisfy the filter
            while (iterator.NextNode() != null)
            {
                Aspose.Html.Dom.Node current = iterator.CurrentNode;
                Aspose.Html.HTMLElement element = current as Aspose.Html.HTMLElement;
                if (element != null && element.InnerHTML != null)
                {
                    Console.WriteLine("Node: <{0}> Length: {1}", element.LocalName, element.InnerHTML.Length);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom filter that accepts nodes with InnerHTML length > 200
class OnlyLongContentFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
{
    public override short AcceptNode(Aspose.Html.Dom.Node n)
    {
        Aspose.Html.HTMLElement element = n as Aspose.Html.HTMLElement;
        if (element != null && element.InnerHTML != null && element.InnerHTML.Length > 200)
        {
            return FILTER_ACCEPT;
        }
        return FILTER_SKIP;
    }
}