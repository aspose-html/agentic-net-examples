// Parse an HTML string and collect the text of all paragraph elements using XPath.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>First paragraph.</p><div><p>Second paragraph.</p></div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//p", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Console.WriteLine(node.TextContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}