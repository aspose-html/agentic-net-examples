// Replace double spaces with single spaces in all text nodes to improve readability.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with double spaces
            string htmlContent = "<html><body><p>This  is  a  test.</p><div>Another   example.</div></body></html>";
            // Load the HTML document from the string (base URI is required)
            using (HTMLDocument document = new HTMLDocument(htmlContent, "http://example.com"))
            {
                // Recursively process all nodes starting from the document element
                ProcessNode(document.DocumentElement);
                // Save the modified document
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Traverses the DOM tree and replaces double (or more) spaces with a single space in text nodes
    static void ProcessNode(Node node)
    {
        // If the node is a text node, normalize its whitespace
        if (node is Text textNode)
        {
            // Replace sequences of two or more spaces with a single space
            string normalized = Regex.Replace(textNode.Data, @" {2,}", " ");
            textNode.Data = normalized;
        }

        // Recurse into child nodes
        foreach (Node child in node.ChildNodes)
        {
            ProcessNode(child);
        }
    }
}