// Remove blockquote formatting while preserving the inner text to flatten document structure.

using System;
using System.IO;
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

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
@"<html>
  <body>
    <p>Before blockquote.</p>
    <blockquote>
      <p>Quoted text line 1.</p>
      <p>Quoted text line 2.</p>
    </blockquote>
    <p>After blockquote.</p>
  </body>
</html>");
            }

            // Load the document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Flatten blockquote elements
            FlattenBlockquotes(document.DocumentElement);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void FlattenBlockquotes(Node node)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            Node next = child.NextSibling;

            if (string.Equals(child.NodeName, "blockquote", StringComparison.OrdinalIgnoreCase))
            {
                // Move all children of the blockquote before the blockquote element
                Node inner = child.FirstChild;
                while (inner != null)
                {
                    Node innerNext = inner.NextSibling;
                    // Detach from blockquote and insert before it in the parent
                    child.RemoveChild(inner);
                    node.InsertBefore(inner, child);
                    inner = innerNext;
                }
                // Remove the now empty blockquote element
                node.RemoveChild(child);
            }
            else
            {
                FlattenBlockquotes(child);
            }

            child = next;
        }
    }
}