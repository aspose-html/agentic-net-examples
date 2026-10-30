// Generate an SEO report by extracting title, meta description, and heading hierarchy from a webpage.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

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
    public static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string samplePath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(samplePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample Page</title><meta name=\"description\" content=\"This is a sample page for SEO report.\"></head><body><h1>Heading 1</h1><h2>Subheading 1.1</h2><h3>Sub-subheading</h3><h2>Subheading 1.2</h2></body></html>";
                File.WriteAllText(samplePath, sampleHtml);
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Extract title
                string title = document.Title ?? string.Empty;

                // Extract meta description
                HTMLElement metaDescElem = document.QuerySelector("meta[name='description']") as HTMLElement;
                string description = metaDescElem != null ? metaDescElem.GetAttribute("content") ?? string.Empty : string.Empty;

                // Extract heading hierarchy
                Aspose.Html.Collections.NodeList headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                List<OutlineNode> root = new List<OutlineNode>();
                Stack<OutlineNode> stack = new Stack<OutlineNode>();

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

            Console.WriteLine("SEO reports generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}