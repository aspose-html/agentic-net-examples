// Clone a paragraph node, modify its text color inline, and insert the clone after the original.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.html";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Get the first paragraph element
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length == 0)
            {
                Console.WriteLine("No paragraph elements found.");
                return;
            }
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)paragraphs[0];

            // Clone the paragraph node (deep clone)
            Aspose.Html.HTMLElement clonedParagraph = (Aspose.Html.HTMLElement)paragraph.CloneNode(true);

            // Modify the cloned paragraph's text color inline
            clonedParagraph.Style.Color = "blue";

            // Insert the cloned paragraph after the original
            Node parent = paragraph.ParentNode;
            parent.InsertBefore(clonedParagraph, paragraph.NextSibling);

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}