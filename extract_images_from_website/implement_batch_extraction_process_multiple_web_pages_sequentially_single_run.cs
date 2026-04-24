// Implement batch extraction to process multiple web pages sequentially in a single run.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

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
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "input";
                string outputFolder = "output";

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    // Load HTML document
                    HTMLDocument document = new HTMLDocument(htmlPath);

                    // Select all heading elements (h1-h6)
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
                    string json = System.Text.Json.JsonSerializer.Serialize(
                        root,
                        new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

                    // Write JSON file
                    string jsonPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                    File.WriteAllText(jsonPath, json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}