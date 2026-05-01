// Evaluate the XPath expression with Document.Evaluate to obtain the image node collection.

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
            // Path to the HTML file to be processed
            string htmlPath = "sample.html";

            // Load the HTML document
            HTMLDocument doc = new HTMLDocument(htmlPath);

            // XPath expression to select image elements
            string xpath = "//img";

            // Evaluate the XPath expression
            IXPathResult result = doc.Evaluate(xpath, doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            // Iterate over the resulting nodes
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                // Cast each node to an HTMLImageElement and output its src attribute
                HTMLImageElement img = (HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}