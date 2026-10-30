// Count the number of <img> nodes using XPath and output the total count.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><img src='a.png'/><div><img src='b.jpg'/></div></body></html>";
            var doc = new Aspose.Html.HTMLDocument(html, "about:blank");
            var result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            int count = 0;
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                count++;
            }
            Console.WriteLine($"Total <img> nodes: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}