// Use XPath to select all table cells containing numeric values and calculate their sum programmatically.

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
            // Load the HTML document from a file
            HTMLDocument doc = new HTMLDocument("input.html");

            // XPath to select all table cell elements
            string xpath = "//td";

            // Evaluate the XPath expression
            IXPathResult result = doc.Evaluate(xpath, doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            double sum = 0;

            // Iterate over each selected cell node
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                // Get the text content of the cell and trim whitespace
                string text = node.TextContent?.Trim();

                // Try to parse the text as a double; if successful, add to sum
                if (double.TryParse(text, out double value))
                {
                    sum += value;
                }
            }

            Console.WriteLine($"Sum of numeric table cells: {sum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}