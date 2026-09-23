// Load a local HTML file and retrieve the page title using an XPath expression.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample Title</title></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            string xpath = "//title";
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                xpath,
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node = result.IterateNext();
            if (node != null)
            {
                string title = node.TextContent;
                Console.WriteLine("Page title: " + title);
            }
            else
            {
                Console.WriteLine("Title element not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}