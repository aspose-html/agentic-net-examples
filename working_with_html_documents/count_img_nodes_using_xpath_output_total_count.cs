// Count the number of <img> nodes using XPath and output the total count.

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
            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument("input.html");

            // Evaluate XPath to select all <img> elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);

            // Iterate over the result and count the nodes
            Aspose.Html.Dom.Node node;
            int count = 0;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                count++;
            }

            // Output the total count
            Console.WriteLine($"Total <img> nodes: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}