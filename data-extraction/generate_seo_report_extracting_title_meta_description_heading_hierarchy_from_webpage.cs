// Generate an SEO report by extracting title, meta description, and heading hierarchy from a webpage.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;

public class OutlineNode
{
    public string Text { get; set; }
    public int Level { get; set; }
    public List<OutlineNode> Children { get; set; }
}

public class SeoReport
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<OutlineNode> Headings { get; set; }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputJson";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample Page</title>
    <meta name=""description"" content=""This is a sample description for SEO report."">
</head>
<body>
    <h1>Welcome to Sample Page</h1>
    <h2>Section One</h2>
    <h3>Subsection A</h3>
    <h2>Section Two</h2>
    <h3>Subsection B</h3>
    <h4>Detail Level</h4>
</body>
</html>";
                File.WriteAllText(samplePath, sampleContent);
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Extract title
                string title = document.Title ?? string.Empty;

                // Extract meta description
                Aspose.Html.HTMLElement metaDescElement = document.QuerySelector("meta[name='description']") as Aspose.Html.HTMLElement;
                string description = metaDescElement != null ? metaDescElement.GetAttribute("content") ?? string.Empty : string.Empty;

                // Extract headings hierarchy
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

                // Build report object
                SeoReport report = new SeoReport
                {
                    Title = title,
                    Description = description,
                    Headings = root
                };

                string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
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