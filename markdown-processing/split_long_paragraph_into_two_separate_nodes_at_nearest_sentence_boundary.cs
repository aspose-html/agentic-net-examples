// Split a long paragraph into two separate nodes at the nearest sentence boundary.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create a paragraph with a long text
            string longText = "Lorem ipsum dolor sit amet. Consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(longText);
            paragraph.AppendChild(textNode);
            body.AppendChild(paragraph);

            // Split the paragraph at the nearest sentence boundary (first period)
            string fullText = paragraph.TextContent;
            int splitIndex = fullText.IndexOf('.') + 1; // include the period
            if (splitIndex > 0 && splitIndex < fullText.Length)
            {
                string firstPart = fullText.Substring(0, splitIndex).Trim();
                string secondPart = fullText.Substring(splitIndex).Trim();

                // Update the original paragraph with the first part
                paragraph.TextContent = firstPart;

                // Create a new paragraph for the second part
                Aspose.Html.HTMLParagraphElement newParagraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
                Aspose.Html.Dom.Text newTextNode = document.CreateTextNode(secondPart);
                newParagraph.AppendChild(newTextNode);

                // Insert the new paragraph after the original one
                Aspose.Html.Dom.Node nextSibling = paragraph.NextSibling;
                if (nextSibling != null)
                {
                    body.InsertBefore(newParagraph, nextSibling);
                }
                else
                {
                    body.AppendChild(newParagraph);
                }
            }

            // Save the document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}