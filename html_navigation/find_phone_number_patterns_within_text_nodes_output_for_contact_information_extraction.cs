// Find phone number patterns within text nodes and output them for contact information extraction.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing phone numbers
            string html = "<html><body><p>Contact us at 123-456-7890 or (555) 123 4567.</p><div>Another number: +1 800 555 0199.</div></body></html>";
            string baseUri = "http://example.com";

            // Create an HTMLDocument from the raw HTML string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);

            // Select all text nodes in the document using XPath
            IXPathResult result = document.Evaluate("//text()", document, null, XPathResultType.Any, null);

            // Regular expression to match typical phone number patterns
            Regex phoneRegex = new Regex(@"\+?\d[\d\s\-\(\)]{7,}\d");

            // Iterate over each text node and extract phone numbers
            for (Node node; (node = result.IterateNext()) != null;)
            {
                string text = node.TextContent;
                foreach (Match match in phoneRegex.Matches(text))
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}