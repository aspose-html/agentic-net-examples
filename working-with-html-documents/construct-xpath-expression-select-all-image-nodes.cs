// Construct an XPath expression "//img" to select all image nodes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><img src='image1.png'/><p>Sample text</p><img src='image2.jpg'/></body></html>";
            var doc = new Aspose.Html.HTMLDocument(html, "about:blank");

            var result = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                var img = (Aspose.Html.HTMLImageElement)node;
                System.Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}