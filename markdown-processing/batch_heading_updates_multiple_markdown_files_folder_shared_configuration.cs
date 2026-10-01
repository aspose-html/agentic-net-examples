// Perform batch heading updates across multiple Markdown files in a folder using a shared configuration.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

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
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputJson";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                using (var document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                    var root = new List<OutlineNode>();
                    var stack = new Stack<OutlineNode>();

                    for (int i = 0; i < headings.Length; i++)
                    {
                        var element = (Aspose.Html.HTMLElement)headings[i];
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
                    string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                    File.WriteAllText(jsonPath, json);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}