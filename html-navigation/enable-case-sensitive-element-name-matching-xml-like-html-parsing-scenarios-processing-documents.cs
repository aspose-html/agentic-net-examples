// Enable case‑sensitive element name matching for XML‑like HTML parsing scenarios when processing specific documents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<Root><Item>One</Item><item>Two</item></Root>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//Item", document, document.CreateNSResolver(document), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                System.Console.WriteLine(((Aspose.Html.Dom.Element)node).TagName);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}