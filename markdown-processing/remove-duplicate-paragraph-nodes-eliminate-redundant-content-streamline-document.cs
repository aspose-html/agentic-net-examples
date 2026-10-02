// Remove duplicate paragraph nodes to eliminate redundant content and streamline the document.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a sample HTML file with duplicate paragraphs
            string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<p>First paragraph.</p>
<p>Second paragraph.</p>
<p>First paragraph.</p>
<p>Third paragraph.</p>
<p>Second paragraph.</p>
</body>
</html>";
            File.WriteAllText(inputPath, sampleHtml);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // Get all paragraph elements
            Aspose.Html.Collections.HTMLCollection paragraphs = doc.GetElementsByTagName("p");

            // Track seen paragraph texts
            HashSet<string> seenTexts = new HashSet<string>();

            // Iterate backwards to safely remove nodes
            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)paragraphs[i];
                string text = p.TextContent ?? string.Empty;

                if (!seenTexts.Add(text))
                {
                    // Duplicate found, remove from its parent
                    Node parent = p.ParentNode;
                    if (parent != null)
                    {
                        parent.RemoveChild(p);
                    }
                }
            }

            // Save the cleaned document
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}