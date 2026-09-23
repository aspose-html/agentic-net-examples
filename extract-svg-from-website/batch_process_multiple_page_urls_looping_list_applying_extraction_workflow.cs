// Batch process multiple page URLs by looping through a list and applying the extraction workflow.

using System;
using System.IO;
using System.Collections.Generic;
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
            string outputFolder = "Output";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] urls = new string[]
            {
                "https://example.com/page1.html",
                "https://example.com/page2.html"
            };

            for (int index = 0; index < urls.Length; index++)
            {
                string url = urls[index];
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                {
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
                    string jsonPath = Path.Combine(outputFolder, $"outline_{index + 1}.json");
                    File.WriteAllText(jsonPath, json);
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}