// Batch process multiple page URLs by looping through a list and applying the extraction workflow.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

namespace BatchHeadingExtraction
{
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // List of page URLs to process
                string[] urls = new string[]
                {
                    "https://example.com/page1.html",
                    "https://example.com/page2.html"
                };

                // Folder to store JSON results
                string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                foreach (string url in urls)
                {
                    // Load the HTML document from the URL
                    HTMLDocument document = new HTMLDocument(url);

                    // Select all heading elements
                    var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                    var root = new List<OutlineNode>();
                    var stack = new Stack<OutlineNode>();

                    for (int i = 0; i < headings.Length; i++)
                    {
                        HTMLElement element = (HTMLElement)headings[i];
                        string tag = element.TagName.ToLower();
                        int level = int.Parse(tag.Substring(1));

                        OutlineNode node = new OutlineNode
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

                    // Serialize outline to JSON
                    string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });

                    // Save JSON file named after the URL host and path
                    string fileName = $"{new Uri(url).Host}_{Path.GetFileNameWithoutExtension(new Uri(url).AbsolutePath)}.json";
                    string jsonPath = Path.Combine(outputFolder, fileName);
                    File.WriteAllText(jsonPath, json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}