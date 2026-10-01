// Extract the value of the robots meta tag to determine indexing directives.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"robots\" content=\"noindex, nofollow\"><title>Test</title></head><body><p>Hello</p></body></html>";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//meta[@name='robots']", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node = result.IterateNext();
            if (node != null)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)node;
                string content = element.GetAttribute("content");
                System.Console.WriteLine("Robots meta content: " + content);
            }
            else
            {
                System.Console.WriteLine("Robots meta tag not found.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}