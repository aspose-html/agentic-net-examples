// Clone a paragraph node, modify its text color inline, and insert the clone after the original.

using System;
using System.Linq;
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
            // Path where the modified HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Get the first <p> element in the document
                HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();

                // Clone the paragraph (deep clone to copy its children)
                HTMLElement clone = (HTMLElement)paragraph.CloneNode(true);

                // Change the text color of the cloned paragraph using inline CSS
                clone.Style.Color = "#FF0000";

                // Insert the cloned paragraph after the original one
                // If the original paragraph has no next sibling, InsertBefore with null appends at the end
                paragraph.ParentNode.InsertBefore(clone, paragraph.NextSibling);

                // Save the modified document
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}