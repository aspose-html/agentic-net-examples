// Retrieve the inner text of the first paragraph inside a div with a specific class using XPath.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><div class='target'><p>First paragraph</p><p>Second paragraph</p></div></body></html>";
            HTMLDocument document = new HTMLDocument(html, "about:blank");

            IXPathResult result = document.Evaluate("//div[contains(@class,'target')]/p[1]", document, null, XPathResultType.Any, null);
            Node node = result.IterateNext();

            string extractedText = string.Empty;
            if (node != null && node is HTMLElement element)
            {
                extractedText = element.TextContent;
            }

            Console.WriteLine("Extracted text: " + extractedText);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}