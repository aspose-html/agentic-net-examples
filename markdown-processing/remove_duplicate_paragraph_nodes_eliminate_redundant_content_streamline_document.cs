// Remove duplicate paragraph nodes to eliminate redundant content and streamline the document.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a sample HTML file with duplicate paragraphs if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<p>First paragraph.</p>" +
                                    "<p>Second paragraph.</p>" +
                                    "<p>First paragraph.</p>" + // duplicate
                                    "<p>Third paragraph.</p>" +
                                    "<p>Second paragraph.</p>" + // duplicate
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all paragraph elements
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");

            // Use a hash set to track unique paragraph texts
            HashSet<string> seenTexts = new HashSet<string>();

            // Iterate backwards to safely remove nodes while iterating
            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)paragraphs[i];
                string text = paragraph.TextContent ?? string.Empty;

                if (!seenTexts.Add(text))
                {
                    // Duplicate found – remove the paragraph from its parent
                    Aspose.Html.Dom.Node parent = paragraph.ParentNode;
                    if (parent != null)
                    {
                        parent.RemoveChild(paragraph);
                    }
                }
            }

            // Save the cleaned document
            document.Save(outputPath);

            Console.WriteLine("Duplicate paragraphs removed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}