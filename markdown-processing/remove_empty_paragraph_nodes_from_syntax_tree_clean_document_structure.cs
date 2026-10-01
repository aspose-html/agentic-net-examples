// Remove all empty paragraph nodes from the syntax tree to clean up the document structure.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><p>First paragraph.</p><p></p><p>   </p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove empty paragraph nodes
            RemoveEmptyParagraphs(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);

            Console.WriteLine("Empty paragraphs removed and document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RemoveEmptyParagraphs(Node node)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            Node next = child.NextSibling;

            if (child.NodeName == "p")
            {
                // Check if the paragraph is empty (no child nodes)
                if (child.FirstChild == null)
                {
                    node.RemoveChild(child);
                }
                else
                {
                    // If the only child is a text node with whitespace, treat as empty
                    Node inner = child.FirstChild;
                    if (inner.NodeName == "#text" && string.IsNullOrWhiteSpace(inner.NodeValue) && inner.NextSibling == null)
                    {
                        node.RemoveChild(child);
                    }
                    else
                    {
                        // Recursively process inner nodes
                        RemoveEmptyParagraphs(child);
                    }
                }
            }
            else
            {
                // Recursively process other nodes
                RemoveEmptyParagraphs(child);
            }

            child = next;
        }
    }
}