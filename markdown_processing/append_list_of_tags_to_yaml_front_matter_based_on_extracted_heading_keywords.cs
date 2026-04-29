// Append a list of tags to the YAML front‑matter based on extracted heading keywords.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define folders
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputMarkdown";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Extract headings (h1-h6)
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                // Build outline nodes
                var root = new List<OutlineNode>();
                var stack = new Stack<OutlineNode>();

                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement element = (HTMLElement)headings[i];
                    string tag = element.TagName.ToLower();
                    int level = int.Parse(tag.Substring(1));

                    var node = new OutlineNode
                    {
                        Text = element.TextContent.Trim(),
                        Level = level,
                        Children = new List<OutlineNode>()
                    };

                    while (stack.Count > 0 && stack.Peek().Level >= level)
                        stack.Pop();

                    if (stack.Count == 0)
                        root.Add(node);
                    else
                        stack.Peek().Children.Add(node);

                    stack.Push(node);
                }

                // Collect unique heading keywords as tags
                var tags = new HashSet<string>();
                void CollectTags(IEnumerable<OutlineNode> nodes)
                {
                    foreach (var n in nodes)
                    {
                        if (!string.IsNullOrWhiteSpace(n.Text))
                        {
                            string tag = n.Text.Trim()
                                              .ToLower()
                                              .Replace(' ', '-')
                                              .Replace(".", "")
                                              .Replace(",", "");
                            tags.Add(tag);
                        }
                        if (n.Children != null && n.Children.Count > 0)
                            CollectTags(n.Children);
                    }
                }
                CollectTags(root);

                // Prepare Markdown file with YAML front‑matter
                string markdownPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".md");
                string markdownContent = File.ReadAllText(htmlPath); // placeholder: convert HTML to markdown if needed

                // Insert or update YAML front‑matter
                string yamlHeader = "---\n";
                yamlHeader += "tags:\n";
                foreach (var t in tags)
                    yamlHeader += $"  - {t}\n";
                yamlHeader += "---\n\n";

                // Simple approach: replace existing front‑matter if present
                string finalContent;
                if (markdownContent.StartsWith("---"))
                {
                    int secondDelimiter = markdownContent.IndexOf("---", 3);
                    if (secondDelimiter != -1)
                    {
                        finalContent = yamlHeader + markdownContent.Substring(secondDelimiter + 3).TrimStart();
                    }
                    else
                    {
                        finalContent = yamlHeader + markdownContent;
                    }
                }
                else
                {
                    finalContent = yamlHeader + markdownContent;
                }

                File.WriteAllText(markdownPath, finalContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper class for outline nodes
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }
}