// Retrieve the inner text of the first paragraph inside a div with a specific class using XPath.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><div class='target'><p>Hello World</p><p>Second</p></div></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var result = document.Evaluate("//div[contains(@class,'target')]/p[1]", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            var node = result.IterateNext();
            string text = (node as Aspose.Html.Dom.Element)?.TextContent;
            Console.WriteLine(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}