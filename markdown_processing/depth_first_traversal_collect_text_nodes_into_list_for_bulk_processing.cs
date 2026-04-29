// Perform a depth‑first traversal to collect all text nodes into a list for bulk processing.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML source; replace with your own source or load from file/URL as needed
            string html = "<html><body><p>Hello <b>World</b>!<span>Test</span></p></body></html>";
            // Create an in‑memory HTML document with a base URI
            HTMLDocument document = new HTMLDocument(html, "http://example.com");

            // Create a NodeIterator that will walk the whole document in depth‑first order
            INodeIterator iterator = document.CreateNodeIterator(document);

            // List to hold all text nodes found during traversal
            List<Node> textNodes = new List<Node>();

            // Iterate over nodes; NextNode returns the next node in document order or null when finished
            for (Node node = iterator.NextNode(); node != null; node = iterator.NextNode())
            {
                // Filter only text nodes (Node.TEXT_NODE constant)
                if (node.NodeType == Node.TEXT_NODE)
                {
                    textNodes.Add(node);
                }
            }

            // Example bulk processing: output the text content of each collected node
            foreach (Node textNode in textNodes)
            {
                Console.WriteLine(textNode.TextContent);
            }
        }
        catch (Exception ex)
        {
            // Simple error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}