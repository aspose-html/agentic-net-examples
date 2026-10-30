// Load a local HTML file and retrieve the page title using an XPath expression.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample Title</title></head><body><p>Hello World</p></body></html>";
                System.IO.File.WriteAllText(inputPath, htmlContent);
            }

            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//title", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
                Aspose.Html.Dom.Node node = result.IterateNext();
                string title = string.Empty;

                if (node != null)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)node;
                    title = element.TextContent;
                }

                System.Console.WriteLine("Page title: " + title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}