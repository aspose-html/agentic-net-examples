// Retrieve the inner text of the first paragraph inside a div with a specific class using XPath.

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
            string html = "<html><body><div class='target'><p>Hello World</p></div></body></html>";
            string baseUri = "http://example.com";

            HTMLDocument document = new HTMLDocument(html, baseUri);
            string xpath = "(//div[contains(@class,'target')]//p)[1]";
            IXPathResult result = document.Evaluate(xpath, document, null, XPathResultType.Any, null);
            Node node = result.IterateNext();
            if (node != null)
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