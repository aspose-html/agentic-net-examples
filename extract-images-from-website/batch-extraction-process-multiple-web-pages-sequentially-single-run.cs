// Implement batch extraction to process multiple web pages sequentially in a single run.

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
            string inputFolder = "input_html";
            string outputFolder = "output_json";

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
@"<html>
<head><title>Sample</title></head>
<body>
<h1>Title</h1>
<h2>Section 1</h2>
<h3>Subsection 1.1</h3>
<h2>Section 2</h2>
</body>
</html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
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
            }

            Console.WriteLine("Batch extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}