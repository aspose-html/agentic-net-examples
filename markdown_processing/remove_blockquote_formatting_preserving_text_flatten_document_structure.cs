// Remove blockquote formatting while preserving the inner text to flatten document structure.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document from a file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all blockquote elements
            NodeList blockquotes = document.QuerySelectorAll("blockquote");

            // Iterate over a static copy of the list to avoid modification issues
            foreach (HTMLElement blockquote in blockquotes)
            {
                // Move each child of the blockquote to its parent, before the blockquote
                while (blockquote.FirstChild != null)
                {
                    Node child = blockquote.FirstChild;
                    blockquote.ParentNode.InsertBefore(child, blockquote);
                }

                // Remove the now empty blockquote element
                blockquote.ParentNode.RemoveChild(blockquote);
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}