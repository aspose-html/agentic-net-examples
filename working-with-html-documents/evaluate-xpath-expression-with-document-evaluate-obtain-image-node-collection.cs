// Evaluate the XPath expression with Document.Evaluate to obtain the image node collection.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src='image1.png'/><div><img src='image2.jpg'/></div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                "//img",
                document,
                document.CreateNSResolver(document),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

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