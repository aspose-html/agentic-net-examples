// Enable case‑sensitive element name matching for XML‑like HTML parsing scenarios when processing specific documents.

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
            string htmlContent = "<Root><Child>Value</Child></Root>";
            // Load HTML content with a placeholder base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Use XPath to perform case‑sensitive element selection
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                "//Root/Child",
                document,
                document.CreateNSResolver(document),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                // Cast to Element to access TagName
                Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    Console.WriteLine(element.TagName);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}