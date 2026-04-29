// Remove duplicate paragraph nodes to eliminate redundant content and streamline the document.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

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
            HTMLCollection paragraphs = document.GetElementsByTagName("p");

            // Track unique paragraph content
            HashSet<string> seen = new HashSet<string>();

            // Iterate through the collection and remove duplicates
            for (int i = 0; i < paragraphs.Length; i++)
            {
                HTMLElement paragraph = (HTMLElement)paragraphs[i];
                string content = paragraph.OuterHTML;

                if (!seen.Add(content))
                {
                    Node parent = paragraph.ParentNode;
                    if (parent != null)
                    {
                        parent.RemoveChild(paragraph);
                        i--; // Adjust index after removal
                    }
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