// Split a long paragraph into two separate nodes at the nearest sentence boundary.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample Heading</h1><p>This is a long paragraph. It contains multiple sentences. Here is another sentence.</p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Find the first paragraph element
                Aspose.Html.Dom.Node node = document.Body.FirstChild;
                while (node != null && !(node is Aspose.Html.HTMLParagraphElement))
                {
                    node = node.NextSibling;
                }

                if (node != null)
                {
                    string fullText = node.TextContent;
                    // Find nearest sentence boundary (period) around the middle of the text
                    int splitIndex = fullText.LastIndexOf('.', fullText.Length / 2);
                    if (splitIndex != -1 && splitIndex + 1 < fullText.Length)
                    {
                        string firstPart = fullText.Substring(0, splitIndex + 1).Trim();
                        string secondPart = fullText.Substring(splitIndex + 1).Trim();

                        // Update original paragraph with the first part
                        node.TextContent = firstPart;

                        // Create a new paragraph for the second part
                        Aspose.Html.HTMLParagraphElement newParagraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
                        Aspose.Html.Dom.Text secondTextNode = document.CreateTextNode(secondPart);
                        newParagraph.AppendChild(secondTextNode);

                        // Insert the new paragraph after the original one
                        Aspose.Html.Dom.Node nextSibling = node.NextSibling;
                        document.Body.InsertBefore(newParagraph, nextSibling);
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}