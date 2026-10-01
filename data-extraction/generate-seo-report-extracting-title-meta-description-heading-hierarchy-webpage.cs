// Generate an SEO report by extracting title, meta description, and heading hierarchy from a webpage.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace SeoReportGenerator
{
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }

    class SeoReport
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<OutlineNode> Headings { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = "InputHtml";
                string outputFolder = "SeoReports";

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                if (!Directory.Exists(inputFolder))
                    Directory.CreateDirectory(inputFolder);

                // Create a sample HTML file if none exist
                if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
                {
                    string samplePath = Path.Combine(inputFolder, "sample.html");
                    File.WriteAllText(samplePath,
@"<html>
<head>
<title>Sample Page</title>
<meta name='description' content='This is a sample description for SEO testing.'>
</head>
<body>
<h1>Welcome to Sample</h1>
<h2>Section One</h2>
<h3>Subsection A</h3>
<h2>Section Two</h2>
<h3>Subsection B</h3>
<h4>Detail</h4>
</body>
</html>");
                }

                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    // Load HTML document
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                    // Extract title
                    string title = document.Title ?? string.Empty;

                    // Extract meta description
                    Aspose.Html.HTMLElement metaDescElement = document.QuerySelector("meta[name='description']") as Aspose.Html.HTMLElement;
                    string description = metaDescElement?.GetAttribute("content") ?? string.Empty;

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

                    // Serialize to JSON
                    string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });

                    // Write JSON file
                    string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + "_seo.json");
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
}