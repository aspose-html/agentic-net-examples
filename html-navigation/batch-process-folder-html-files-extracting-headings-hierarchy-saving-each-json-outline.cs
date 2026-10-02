// Batch process a folder of HTML files, extracting headings hierarchy and saving each as a JSON outline.

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
            string inputFolder = "HTMLFiles";
            string outputFolder = "JsonOut";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath,
                    "<html><body>" +
                    "<h1>Main Title</h1>" +
                    "<h2>Section 1</h2>" +
                    "<h3>Subsection 1.1</h3>" +
                    "<h2>Section 2</h2>" +
                    "</body></html>");
            }

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
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}