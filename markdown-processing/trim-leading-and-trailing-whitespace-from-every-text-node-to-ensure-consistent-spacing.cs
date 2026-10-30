// Trim leading and trailing whitespace from every text node to ensure consistent spacing.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><div>   Hello   <span>  World </span>   </div><p>   Sample   text   </p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                TrimTextNodes(document);
                string resultHtml = document.DocumentElement.OuterHTML;
                System.Console.WriteLine(resultHtml);
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void TrimTextNodes(Aspose.Html.Dom.Node node)
    {
        if (node.NodeType == Aspose.Html.Dom.Node.TEXT_NODE)
        {
            node.TextContent = node.TextContent.Trim();
        }

        Aspose.Html.Collections.NodeList children = node.ChildNodes;
        for (int i = 0; i < children.Length; i++)
        {
            TrimTextNodes(children[i]);
        }
    }
}