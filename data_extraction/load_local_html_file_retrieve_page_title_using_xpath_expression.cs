// Load a local HTML file and retrieve the page title using an XPath expression.

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
            string filePath = "sample.html";
            using (HTMLDocument document = new HTMLDocument(filePath))
            {
                IXPathResult result = document.Evaluate("//title", document, document.CreateNSResolver(document), XPathResultType.Any, null);
                Node node = result.IterateNext();
                Element titleElement = node as Element;
                string title = titleElement != null ? titleElement.TextContent : string.Empty;
                Console.WriteLine(title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}