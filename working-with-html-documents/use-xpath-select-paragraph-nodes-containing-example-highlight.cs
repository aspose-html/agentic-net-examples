// Use XPath to select paragraph nodes containing the word "example" and highlight them.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>This is an example paragraph.</p><p>Another paragraph.</p><p>Example again.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            string xpathExpression = "//p[contains(., 'example') or contains(., 'Example')]";
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                xpathExpression,
                document,
                null,
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                var element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    element.SetAttribute("style", "background-color:yellow;");
                }
            }

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}