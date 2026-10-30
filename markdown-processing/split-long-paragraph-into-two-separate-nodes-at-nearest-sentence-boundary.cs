// Split a long paragraph into two separate nodes at the nearest sentence boundary.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a long paragraph
            string htmlContent = "<html><body><p>This is a long paragraph. It contains multiple sentences. Here is another sentence.</p></body></html>";

            // Load the HTML document from the string (base URI is not needed)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the first paragraph element
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length == 0)
            {
                Console.WriteLine("No paragraph found.");
                return;
            }

            Aspose.Html.HTMLParagraphElement originalParagraph = (Aspose.Html.HTMLParagraphElement)paragraphs[0];
            string fullText = originalParagraph.TextContent;

            // Find a sentence boundary near the middle of the text
            int middle = fullText.Length / 2;
            int splitPos = fullText.IndexOf('.', middle);
            if (splitPos == -1)
            {
                Console.WriteLine("Unable to find a sentence boundary to split.");
                return;
            }
            splitPos++; // Include the period

            string firstPart = fullText.Substring(0, splitPos).Trim();
            string secondPart = fullText.Substring(splitPos).Trim();

            // Update the original paragraph with the first part
            originalParagraph.TextContent = firstPart;

            // Create a new paragraph for the second part
            Aspose.Html.HTMLParagraphElement newParagraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            Aspose.Html.Dom.Text newTextNode = document.CreateTextNode(secondPart);
            newParagraph.AppendChild(newTextNode);

            // Insert the new paragraph after the original one
            Aspose.Html.Dom.Node parent = originalParagraph.ParentNode;
            Aspose.Html.Dom.Node nextSibling = originalParagraph.NextSibling;
            if (nextSibling != null)
            {
                parent.InsertBefore(newParagraph, nextSibling);
            }
            else
            {
                parent.AppendChild(newParagraph);
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}