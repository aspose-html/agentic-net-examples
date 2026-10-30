// Load all .md files from a directory and parse each into separate syntax trees.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputFolder, "*.md").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Sample Title\n\n## Subsection\nContent line");
            }

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                string[] lines = File.ReadAllLines(mdPath);
                var root = new List<SyntaxNode>();
                var stack = new Stack<SyntaxNode>();

                foreach (string line in lines)
                {
                    if (line.StartsWith("#"))
                    {
                        int level = line.TakeWhile(c => c == '#').Count();
                        string text = line.Substring(level).Trim();

                        var node = new SyntaxNode
                        {
                            Text = text,
                            Level = level,
                            Children = new List<SyntaxNode>()
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
                string jsonPath = Path.Combine(inputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".json");
                File.WriteAllText(jsonPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class SyntaxNode
{
    public string Text { get; set; }
    public int Level { get; set; }
    public List<SyntaxNode> Children { get; set; }
}