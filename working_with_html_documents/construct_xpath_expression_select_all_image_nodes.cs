// Construct an XPath expression "//img" to select all image nodes.

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
            HTMLDocument doc = new HTMLDocument("input.html");
            IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                HTMLImageElement img = (HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}