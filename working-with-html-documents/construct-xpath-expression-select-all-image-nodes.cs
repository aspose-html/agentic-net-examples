// Construct an XPath expression "//img" to select all image nodes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><img src='image1.png'/><p>Text</p><img src='image2.jpg'/></body></html>";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}