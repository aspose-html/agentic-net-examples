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
            // Input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <!-- TODO: Update the title -->
</head>
<body>
    <h1>Hello World</h1>
    <!-- This is a regular comment -->
    <!-- TODO: Add more content here -->
    <p>Sample paragraph.</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // List to hold TODO comments
            List<string> todoComments = new List<string>();

            // Extract TODO comments recursively
            ExtractTodoComments(document.DocumentElement, todoComments);

            // Output the extracted TODO comments
            Console.WriteLine("Extracted TODO comments:");
            foreach (string comment in todoComments)
            {
                Console.WriteLine(comment.Trim());
            }

            // Optionally, save the document unchanged
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ExtractTodoComments(Node node, List<string> list)
    {
        Node child = node.FirstChild;
        while (child != null)
        {
            Node next = child.NextSibling;

            if (child.NodeName == "#comment")
            {
                string commentText = child.NodeValue ?? string.Empty;
                if (commentText.IndexOf("TODO", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    list.Add(commentText);
                }
            }
            else
            {
                ExtractTodoComments(child, list);
            }

            child = next;
        }
    }
}