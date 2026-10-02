// Remove an existing YAML front‑matter block to revert the document to plain Markdown.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.md";
            string outputPath = "sample_clean.md";

            // Create a sample markdown file with YAML front‑matter if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleContent = @"---
title: Sample Document
author: John Doe
date: 2023-01-01
---
# Hello World

This is a sample markdown file.";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Read the markdown content
            string content = File.ReadAllText(inputPath);

            // Remove YAML front‑matter block (delimited by lines containing only "---")
            string cleanedContent = RemoveYamlFrontMatter(content);

            // Save the cleaned markdown
            File.WriteAllText(outputPath, cleanedContent);

            Console.WriteLine("YAML front‑matter removed successfully.");
            Console.WriteLine("Cleaned markdown saved at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static string RemoveYamlFrontMatter(string markdown)
    {
        // Trim leading whitespace for reliable detection
        string trimmed = markdown.TrimStart();

        // YAML front‑matter must start with "---" on its own line
        if (!trimmed.StartsWith("---"))
            return markdown; // No front‑matter found

        // Find the end delimiter (second line with only "---")
        int startIndex = markdown.IndexOf("---");
        if (startIndex == -1)
            return markdown;

        // Search for the next delimiter after the first line
        int endIndex = markdown.IndexOf("\n---", startIndex + 3);
        if (endIndex == -1)
            return markdown; // No closing delimiter; leave unchanged

        // Include the newline after the closing delimiter
        int afterEnd = markdown.IndexOf('\n', endIndex + 4);
        if (afterEnd == -1)
            afterEnd = markdown.Length;

        // Remove the front‑matter block
        return markdown.Remove(startIndex, afterEnd - startIndex);
    }
}