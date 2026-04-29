// Merge consecutive paragraph nodes into a single paragraph to reduce unnecessary breaks.

using System;
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

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all paragraph elements
            var paragraphs = document.QuerySelectorAll("p");
            // Iterate over the collection
            for (int i = 0; i < paragraphs.Length; i++)
            {
                var current = (HTMLElement)paragraphs[i];
                // Merge consecutive sibling paragraphs
                while (true)
                {
                    var next = current.NextSibling as HTMLElement;
                    if (next == null || next.TagName.ToLower() != "p")
                        break;

                    // Move all child nodes from next paragraph to current paragraph
                    while (next.HasChildNodes())
                    {
                        var child = next.FirstChild;
                        next.RemoveChild(child);
                        current.AppendChild(child);
                    }

                    // Remove the now empty next paragraph from its parent
                    var parent = next.ParentNode;
                    parent.RemoveChild(next);
                }
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