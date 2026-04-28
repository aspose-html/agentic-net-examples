// Batch process a folder of HTML files, extracting headings hierarchy and saving each as a JSON outline.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                var root = new List<OutlineNode>();
                var stack = new Stack<OutlineNode>();
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement element = (HTMLElement)headings[i];
                    string tag = element.TagName.ToLower();
                    int level = int.Parse(tag.Substring(1));
                    OutlineNode node = new OutlineNode();
                    node.Text = element.TextContent.Trim();
                    node.Level = level;
                    node.Children = new List<OutlineNode>();
                    while (stack.Count > 0 && stack.Peek().Level >= level) stack.Pop();
                    if (stack.Count == 0) root.Add(node);
                    else stack.Peek().Children.Add(node);
                    stack.Push(node);
                }
                string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
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