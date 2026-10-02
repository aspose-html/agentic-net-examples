// Detect and extract all comment nodes that contain TODO markers for development tracking.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "todos.txt";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!-- TODO: Refactor this -->\n<html><body><!-- TODO: Add content -->\n<p>Hello</p><!-- Note -->\n</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Extract TODO comments
            List<string> todoComments = new List<string>();
            ExtractTodoComments(document.DocumentElement, todoComments);

            // Save extracted TODO comments to a file
            File.WriteAllLines(outputPath, todoComments);

            // Output to console
            Console.WriteLine("Extracted TODO comments:");
            foreach (string comment in todoComments)
            {
                Console.WriteLine(comment);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ExtractTodoComments(Node node, List<string> todos)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            Node next = child.NextSibling;

            if (child.NodeName == "#comment")
            {
                string commentText = child.NodeValue;
                if (!string.IsNullOrEmpty(commentText) && commentText.Contains("TODO"))
                {
                    todos.Add(commentText.Trim());
                }
            }
            else
            {
                ExtractTodoComments(child, todos);
            }

            child = next;
        }
    }
}