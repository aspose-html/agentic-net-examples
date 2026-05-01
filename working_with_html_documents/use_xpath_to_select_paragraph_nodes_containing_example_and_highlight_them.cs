// Use XPath to select paragraph nodes containing the word "example" and highlight them.

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
            string html = "<html><body><p>This is an example paragraph.</p><p>No match here.</p><p>Another example line.</p></body></html>";
            string baseUri = "http://example.com";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);

            string xpath = "//p[contains(., 'example')]";
            IXPathResult result = document.Evaluate(xpath, document, null, XPathResultType.Any, null);

            Node node;
            while ((node = result.IterateNext()) != null)
            {
                if (node is Element element)
                {
                    element.SetAttribute("style", "background-color: yellow;");
                }
            }

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}