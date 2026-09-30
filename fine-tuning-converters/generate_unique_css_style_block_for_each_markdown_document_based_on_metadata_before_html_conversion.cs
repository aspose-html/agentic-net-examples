// Generate a unique CSS style block for each Markdown document based on its metadata before HTML conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content with simple metadata
            string markdownContent = @"---
title: Sample Document
author: John Doe
---
# Heading

This is a sample markdown document.";
            // Extract metadata (title and author)
            string title = "";
            string author = "";
            using (StringReader reader = new StringReader(markdownContent))
            {
                string line;
                bool inFrontMatter = false;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == "---")
                    {
                        inFrontMatter = !inFrontMatter;
                        continue;
                    }
                    if (inFrontMatter)
                    {
                        if (line.StartsWith("title:", StringComparison.OrdinalIgnoreCase))
                        {
                            title = line.Substring(6).Trim();
                        }
                        else if (line.StartsWith("author:", StringComparison.OrdinalIgnoreCase))
                        {
                            author = line.Substring(7).Trim();
                        }
                    }
                }
            }
            // Generate unique CSS based on metadata
            string cssContent = $"body {{ background-color: #f0f0f0; }}\n" +
                                $"h1::before {{ content: \"Title: {title}\"; display: block; font-size: 0.8em; color: #555; }}\n" +
                                $"footer::after {{ content: \"Author: {author}\"; display: block; font-size: 0.8em; color: #555; }}";

            // Convert markdown to HTMLDocument using a memory stream
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdownContent)))
            {
                HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, string.Empty);
                // Ensure <head> exists
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }
                // Create and append style element
                HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                styleElement.TextContent = cssContent;
                head.AppendChild(styleElement);
                // Save the resulting HTML
                string outputPath = "output.html";
                document.Save(outputPath);
                // Output results
                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}