// Output the src attribute values of the image nodes collected via XPath.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src='image1.png'/><div><img src='image2.jpg'/></div></body></html>";
            var doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                var img = (Aspose.Html.HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}