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
            // Define input and output paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                    "<p>First paragraph.</p>" +
                                    "<p>   </p>" + // empty paragraph with whitespace
                                    "<p></p>" +   // truly empty paragraph
                                    "<div><p>Nested paragraph.</p></div>" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Remove empty paragraph nodes
            RemoveEmptyParagraphs(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);

            Console.WriteLine("Empty paragraphs removed successfully.");
            Console.WriteLine($"Input:  {Path.GetFullPath(inputPath)}");
            Console.WriteLine($"Output: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }

    static void RemoveEmptyParagraphs(Node node)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            Node next = child.NextSibling;

            if (child.NodeName.Equals("p", StringComparison.OrdinalIgnoreCase) && IsEmptyParagraph(child))
            {
                node.RemoveChild(child);
            }
            else
            {
                RemoveEmptyParagraphs(child);
            }

            child = next;
        }
    }

    static bool IsEmptyParagraph(Node node)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            // If there is any non-text node, the paragraph is not empty
            if (!child.NodeName.Equals("#text", StringComparison.OrdinalIgnoreCase))
                return false;

            // Check text content for non-whitespace characters
            string text = child.NodeValue as string;
            if (!string.IsNullOrWhiteSpace(text))
                return false;

            child = child.NextSibling;
        }
        // No children or only whitespace text nodes
        return true;
    }
}