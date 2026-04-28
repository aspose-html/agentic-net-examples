// Locate elements matching an XPath expression and replace their outer HTML with a custom snippet.

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
            // Sample HTML content and base URI
            string html = "<html><body><div class='target'><p>Old</p></div></body></html>";
            string baseUri = "http://example.com";

            // Create an HTMLDocument from the string content
            HTMLDocument document = new HTMLDocument(html, baseUri);

            // XPath expression to select elements to replace
            string xpath = "//div[@class='target']";

            // Evaluate the XPath expression
            IXPathResult result = document.Evaluate(xpath, document, null, XPathResultType.Any, null);

            // Iterate over each matched node
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                // Ensure the node is an element before modifying
                if (node is Aspose.Html.HTMLElement element)
                {
                    // Replace the outer HTML of the element with a custom snippet
                    element.OuterHTML = "<section class='new'>New Content</section>";
                }
            }

            // Save the modified document to a file
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}