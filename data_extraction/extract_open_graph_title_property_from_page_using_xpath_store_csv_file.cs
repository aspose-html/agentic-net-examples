// Extract the Open Graph title property from a page using XPath and store it in a CSV file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML page from a URL or local file
            string address = "https://example.com";
            HTMLDocument doc = new HTMLDocument(address);

            // Execute XPath to select the content attribute of the Open Graph title meta tag
            IXPathResult result = doc.Evaluate(
                "//meta[@property='og:title']/@content",
                doc,
                doc.CreateNSResolver(doc),
                XPathResultType.Any,
                null);

            // Retrieve the first matching node (attribute node) and get its value
            Node node;
            string ogTitle = string.Empty;
            while ((node = result.IterateNext()) != null)
            {
                // For attribute nodes, NodeValue holds the attribute's value
                ogTitle = node.NodeValue?.ToString() ?? string.Empty;
                break; // Only need the first occurrence
            }

            // Write the extracted title to a CSV file
            string csvPath = "og_title.csv";
            using (var writer = new StreamWriter(csvPath))
            {
                writer.WriteLine("Title");
                writer.WriteLine($"\"{ogTitle}\"");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}