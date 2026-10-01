// Load all .md files from a directory and parse each into separate syntax trees.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
            string inputFolder = @"C:\InputMarkdown";
            string outputFolder = @"C:\OutputJson";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                var lines = File.ReadAllLines(mdPath);
                var root = new List<OutlineNode>();
                var stack = new Stack<OutlineNode>();

                foreach (var line in lines)
                {
                    var trimmed = line.Trim();
                    if (trimmed.StartsWith("#"))
                    {
                        int level = 0;
                        while (level < trimmed.Length && trimmed[level] == '#')
                            level++;
                        // Ensure there is a space after the hashes
                        if (level < trimmed.Length && trimmed[level] == ' ')
                        {
                            string text = trimmed.Substring(level + 1).Trim();
                            var node = new OutlineNode
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
                }

                string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".json");
                File.WriteAllText(jsonPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}