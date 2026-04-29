// Apply a regular expression to mask email addresses within all text nodes for privacy compliance.

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
            string htmlContent = @"<html><body><p>Contact us at john.doe@example.com or jane@example.org.</p></body></html>";
            string baseUri = "http://example.com";

            // Create HTML document
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Select all text nodes using XPath
            IXPathResult result = document.Evaluate("//text()", document, null, XPathResultType.Any, null);

            // Iterate over each text node and mask email addresses
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                string text = node.NodeValue as string;
                if (!string.IsNullOrEmpty(text))
                {
                    string masked = Regex.Replace(text, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}", "[masked]");
                    node.NodeValue = masked;
                }
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}