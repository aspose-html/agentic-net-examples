// Extract all heading tags (h1‑h6) and build a nested table of contents structure in JSON format.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;

namespace HeadingOutlineExtractor
{
    public class OutlineNode
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
                string inputFolder = "input_html";
                string outputFolder = "output_json";

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    HTMLDocument document = new HTMLDocument(htmlPath);
                    var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                    var root = new List<OutlineNode>();
                    var stack = new Stack<OutlineNode>();

                    for (int i = 0; i < headings.Length; i++)
                    {
                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)headings[i];
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

                    string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
                    string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                    File.WriteAllText(jsonPath, json);
                }

                Console.WriteLine("Heading extraction completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}