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
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample Title</title></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                    "//title",
                    doc,
                    doc.CreateNSResolver(doc),
                    Aspose.Html.Dom.XPath.XPathResultType.Any,
                    null);

                Aspose.Html.Dom.Node node = result.IterateNext();

                if (node != null)
                {
                    Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                    string title = element != null ? element.TextContent : string.Empty;
                    Console.WriteLine("Page title: " + title);
                }
                else
                {
                    Console.WriteLine("Title element not found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}