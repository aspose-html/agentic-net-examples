// Trim leading and trailing whitespace from every text node to ensure consistent spacing.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace TrimTextNodesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample HTML content
                string htmlContent = @"
                    <html>
                        <body>
                            <p>   Hello,   world!   </p>
                            <div>
                                <span>   Sample   text   </span>
                                <!--   Comment with spaces   -->
                            </div>
                        </body>
                    </html>";
                string baseUri = "http://example.com/";

                // Create an HTMLDocument from the string (lifecycle rule)
                using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri))
                {
                    // Recursively trim whitespace from all text nodes
                    TrimTextNodes(document.Body);

                    // Save the modified document
                    string outputPath = "trimmed_output.html";
                    document.Save(outputPath);
                    Console.WriteLine($"Document saved to {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Recursive method to trim leading and trailing whitespace of each Text node
        static void TrimTextNodes(Node node)
        {
            // Process child nodes first
            foreach (Node child in node.ChildNodes)
            {
                TrimTextNodes(child);
            }

            // If the current node is a Text node, trim its data
            if (node is Text textNode && !string.IsNullOrEmpty(textNode.Data))
            {
                textNode.Data = textNode.Data.Trim();
            }
        }
    }
}