// Generate an SEO report by extracting title, meta description, and heading hierarchy from a webpage.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the web page to analyze
            string url = "https://example.com";

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(url);

            // Extract the <title> element text
            var titleElement = document.QuerySelector("title");
            string title = titleElement?.TextContent?.Trim() ?? string.Empty;

            // Extract the meta description content
            var metaDescElement = document.QuerySelector("meta[name='description']");
            string description = metaDescElement?.GetAttribute("content")?.Trim() ?? string.Empty;

            // Extract all heading elements (h1–h6) and build a hierarchical outline
            var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
            var root = new List<OutlineNode>();
            var stack = new Stack<OutlineNode>();

            for (int i = 0; i < headings.Length; i++)
            {
                // Cast each node to HTMLElement to access tag name and text
                HTMLElement element = (HTMLElement)headings[i];
                string tag = element.TagName.ToLower();               // e.g., "h2"
                int level = int.Parse(tag.Substring(1));              // numeric level

                var node = new OutlineNode
                {
                    Text = element.TextContent.Trim(),
                    Level = level,
                    Children = new List<OutlineNode>()
                };

                // Maintain a stack to determine parent-child relationships
                while (stack.Count > 0 && stack.Peek().Level >= level)
                    stack.Pop();

                if (stack.Count == 0)
                    root.Add(node);
                else
                    stack.Peek().Children.Add(node);

                stack.Push(node);
            }

            // Output the extracted information
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Meta Description: " + description);
            Console.WriteLine("Headings Outline (JSON):");
            string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Helper class representing a heading node in the outline
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }
}