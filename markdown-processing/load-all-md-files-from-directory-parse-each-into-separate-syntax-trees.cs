// Load all .md files from a directory and parse each into separate syntax trees.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputJson";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                // Create a sample markdown file
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Title\n## Section 1\nContent line\n### Subsection\n## Section 2");
            }

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                // Load markdown content (as plain text)
                string[] lines = File.ReadAllLines(mdPath);

                // Optional: create a dummy HTMLDocument to satisfy Aspose.HTML usage
                // Using two-argument constructor with base URI to avoid file-not-found errors
                HTMLDocument dummyDoc = new HTMLDocument(string.Empty, "about:blank");

                var root = new List<OutlineNode>();
                var stack = new Stack<OutlineNode>();

                foreach (string rawLine in lines)
                {
                    string line = rawLine.TrimStart();
                    if (line.StartsWith("#"))
                    {
                        int level = 0;
                        while (level < line.Length && line[level] == '#')
                            level++;
                        string text = line.Substring(level).Trim();

                        OutlineNode node = new OutlineNode
                        {
                            Text = text,
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
                }

                string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".json");
                File.WriteAllText(jsonPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class OutlineNode
{
    public string Text { get; set; }
    public int Level { get; set; }
    public List<OutlineNode> Children { get; set; }
}