// Clone a paragraph node, modify its text color inline, and insert the clone after the original.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            // Load document from inline HTML
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the first paragraph element
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p")[0];

            // Clone the paragraph node (deep clone)
            Aspose.Html.Dom.Node clonedNode = paragraph.CloneNode(true);
            Aspose.Html.HTMLElement clonedParagraph = (Aspose.Html.HTMLElement)clonedNode;

            // Modify the cloned paragraph's text color inline
            clonedParagraph.Style.Color = "red";

            // Insert the cloned paragraph after the original
            Aspose.Html.Dom.Node parent = paragraph.ParentNode;
            Aspose.Html.Dom.Node nextSibling = paragraph.NextSibling;
            if (nextSibling != null)
            {
                parent.InsertBefore(clonedParagraph, nextSibling);
            }
            else
            {
                parent.AppendChild(clonedParagraph);
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}