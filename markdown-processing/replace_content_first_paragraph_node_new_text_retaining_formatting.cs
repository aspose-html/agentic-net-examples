// Replace the content of the first paragraph node with new text while retaining its formatting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define output file path
            string outputPath = "output.html";

            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Get reference to the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create a paragraph element
            Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");

            // Apply some formatting to the paragraph (e.g., red color and bold font)
            paragraph.SetAttribute("style", "color: red; font-weight: bold;");

            // Create an initial text node
            Aspose.Html.Dom.Text originalText = document.CreateTextNode("Original paragraph text.");

            // Append the text node to the paragraph
            paragraph.AppendChild(originalText);

            // Append the paragraph to the body
            body.AppendChild(paragraph);

            // Replace the content of the first paragraph's first text node while retaining formatting
            Aspose.Html.HTMLParagraphElement firstParagraph = (Aspose.Html.HTMLParagraphElement)document.Body.GetElementsByTagName("p")[0];

            // Locate the first text node within the paragraph
            Aspose.Html.Dom.Node node = firstParagraph.FirstChild;
            while (node != null && !(node is Aspose.Html.Dom.Text))
            {
                node = node.NextSibling;
            }

            if (node != null)
            {
                ((Aspose.Html.Dom.Text)node).TextContent = "Replaced paragraph text.";
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