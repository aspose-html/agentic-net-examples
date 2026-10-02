// Validate that required fields like title and author exist in the YAML front‑matter block.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with YAML front‑matter
            string htmlContent = @"---
title: Sample Title
author: Jane Doe
---
<html>
<head><title>Test Document</title></head>
<body><p>Hello, World!</p></body>
</html>";

            // Extract YAML front‑matter block
            string frontMatter = ExtractFrontMatter(htmlContent);

            if (string.IsNullOrEmpty(frontMatter))
            {
                Console.WriteLine("No YAML front‑matter block found.");
            }
            else
            {
                // Validate required fields
                bool hasTitle = false;
                bool hasAuthor = false;

                string[] lines = frontMatter.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string trimmed = line.Trim();
                    if (trimmed.StartsWith("title:", StringComparison.OrdinalIgnoreCase))
                        hasTitle = true;
                    else if (trimmed.StartsWith("author:", StringComparison.OrdinalIgnoreCase))
                        hasAuthor = true;
                }

                if (hasTitle && hasAuthor)
                {
                    Console.WriteLine("Validation succeeded: both title and author are present.");
                }
                else
                {
                    if (!hasTitle)
                        Console.WriteLine("Validation error: missing required field 'title'.");
                    if (!hasAuthor)
                        Console.WriteLine("Validation error: missing required field 'author'.");
                }
            }

            // Load the HTML document using Aspose.Html (demonstration purpose)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Document loaded successfully; further processing can be done here.
                Console.WriteLine("HTML document loaded. Title element text: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    private static string ExtractFrontMatter(string content)
    {
        const string delimiter = "---";
        int start = content.IndexOf(delimiter);
        if (start != 0)
            return null;

        int end = content.IndexOf(delimiter, start + delimiter.Length);
        if (end == -1)
            return null;

        // Extract between the two delimiters, excluding them
        int frontStart = start + delimiter.Length;
        string frontMatter = content.Substring(frontStart, end - frontStart).Trim();
        return frontMatter;
    }
}