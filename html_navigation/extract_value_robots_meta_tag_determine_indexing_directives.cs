// Extract the value of the robots meta tag to determine indexing directives.

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
            // Load the HTML document from a file path
            HTMLDocument doc = new HTMLDocument("input.html");

            // Evaluate XPath to select the robots meta tag
            IXPathResult result = doc.Evaluate("//meta[@name='robots']", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            // Iterate over the result (should be at most one element)
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                // Cast the node to Element to access attributes
                Element meta = (Element)node;
                string content = meta.GetAttribute("content");
                Console.WriteLine(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}