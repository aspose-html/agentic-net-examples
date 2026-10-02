// Perform batch heading updates across multiple Markdown files in a folder using a shared configuration.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;

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
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputJson";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputFolder, "*.md").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Title\n## Section 1\n### Subsection A\n## Section 2\n");
            }

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                // Load markdown as HTML document (Aspose.Html can parse markdown files)
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(mdPath);

                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                var root = new List<OutlineNode>();
                var stack = new Stack<OutlineNode>();

                for (int i = 0; i < headings.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)headings[i];
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

                string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".json");
                File.WriteAllText(jsonPath, json);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}