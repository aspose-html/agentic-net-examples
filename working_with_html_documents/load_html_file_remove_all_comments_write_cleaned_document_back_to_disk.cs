// Load an HTML file, remove all comments, and write the cleaned document back to disk.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the cleaned HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Recursively remove comment nodes from the DOM tree
            void RemoveComments(Node node)
            {
                var child = node.FirstChild;
                while (child != null)
                {
                    var next = child.NextSibling;

                    if (child.NodeName == "#comment")
                    {
                        node.RemoveChild(child);
                    }
                    else
                    {
                        RemoveComments(child);
                    }

                    child = next;
                }
            }

            // Start removal from the document element
            RemoveComments(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}