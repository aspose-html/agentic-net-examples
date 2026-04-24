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
            string baseUri = "http://example.com";

            HTMLDocument document = new HTMLDocument(html, baseUri);
            IXPathResult result = document.Evaluate("//p", document, null, XPathResultType.Any, null);
            Node node;
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