// Parse an HTML string and collect the text of all paragraph elements using XPath.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            // Load HTML from a string using a placeholder base URI.
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Evaluate XPath to select all <p> elements.
            IXPathResult result = document.Evaluate("//p", document, null, XPathResultType.Any, null);

            // Iterate over the resulting nodes and output their inner HTML (text content).
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                HTMLElement element = node as HTMLElement;
                if (element != null)
                {
                    Console.WriteLine(element.InnerHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}