// Perform a depth‑first traversal to collect all text nodes into a list for bulk processing.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleHtml = "<html><body><h1>Title</h1><p>Hello <span>World</span>!</p><!-- comment --></body></html>";
                File.WriteAllText(samplePath, sampleHtml);
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    List<string> textNodes = new List<string>();
                    Stack<Node> stack = new Stack<Node>();

                    Node current = document.Body.FirstChild;
                    while (current != null)
                    {
                        stack.Push(current);
                        current = current.NextSibling;
                    }

                    while (stack.Count > 0)
                    {
                        Node node = stack.Pop();

                        if (node is Aspose.Html.Dom.Text textNode)
                        {
                            string txt = textNode.TextContent.Trim();
                            if (!string.IsNullOrEmpty(txt))
                                textNodes.Add(txt);
                        }

                        // Push children to stack for depth‑first traversal
                        Node child = node.FirstChild;
                        while (child != null)
                        {
                            stack.Push(child);
                            child = child.NextSibling;
                        }
                    }

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + "_texts.txt");
                    File.WriteAllLines(outputPath, textNodes);
                }
            }

            Console.WriteLine("Text node extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}