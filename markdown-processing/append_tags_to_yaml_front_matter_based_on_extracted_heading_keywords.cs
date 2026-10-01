// Append a list of tags to the YAML front‑matter based on extracted heading keywords.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputJson";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                var document = new Aspose.Html.HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                var root = new List<OutlineNode>();
                var stack = new Stack<OutlineNode>();
                var tagsSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

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

                    // Extract words as tags
                    var words = node.Text.Split(new char[] { ' ', ',', ';', '.', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var w in words)
                    {
                        var clean = w.Trim().ToLower();
                        if (!string.IsNullOrEmpty(clean))
                            tagsSet.Add(clean);
                    }

                    while (stack.Count > 0 && stack.Peek().Level >= level)
                        stack.Pop();

                    if (stack.Count == 0)
                        root.Add(node);
                    else
                        stack.Peek().Children.Add(node);

                    stack.Push(node);
                }

                var result = new Result
                {
                    Outline = root,
                    Tags = new List<string>(tagsSet)
                };

                string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                File.WriteAllText(jsonPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class OutlineNode
{
    public string Text { get; set; }
    public int Level { get; set; }
    public List<OutlineNode> Children { get; set; }
}

class Result
{
    public List<OutlineNode> Outline { get; set; }
    public List<string> Tags { get; set; }
}