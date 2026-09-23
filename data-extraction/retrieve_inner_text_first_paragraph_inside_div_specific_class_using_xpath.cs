// Retrieve the inner text of the first paragraph inside a div with a specific class using XPath.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><div class='target'><p>Hello World</p><p>Second paragraph</p></div></body></html>";
            var document = new Aspose.Html.HTMLDocument("", html);
            string xpath = "//div[contains(@class,'target')]/p[1]";
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(xpath, document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node = result.IterateNext();
            if (node != null)
            {
                System.Console.WriteLine(node.TextContent);
            }
            else
            {
                System.Console.WriteLine("Paragraph not found.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}