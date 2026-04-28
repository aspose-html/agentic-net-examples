// Generate a navigation sidebar HTML snippet based on extracted heading hierarchy for the site.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output folders
            string inputFolder = @"C:\SiteHtml";
            string outputFolder = @"C:\SiteNav";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the source HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);
                // Select all heading elements
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                // Build outline hierarchy
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

                // Optional: write JSON outline (can be omitted)
                string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                File.WriteAllText(jsonPath, json);

                // Create navigation HTML document
                HTMLDocument navDoc = new HTMLDocument();
                HTMLElement body = navDoc.Body;

                // <nav><ul>...</ul></nav>
                HTMLElement nav = (HTMLElement)navDoc.CreateElement("nav");
                HTMLElement ul = (HTMLElement)navDoc.CreateElement("ul");
                nav.AppendChild(ul);
                body.AppendChild(nav);

                // Recursively build list items
                void AddNodes(HTMLElement parentUl, List<OutlineNode> nodes)
                {
                    foreach (var n in nodes)
                    {
                        HTMLElement li = (HTMLElement)navDoc.CreateElement("li");
                        Text txt = navDoc.CreateTextNode(n.Text);
                        li.AppendChild(txt);
                        parentUl.AppendChild(li);
                        if (n.Children.Count > 0)
                        {
                            HTMLElement childUl = (HTMLElement)navDoc.CreateElement("ul");
                            li.AppendChild(childUl);
                            AddNodes(childUl, n.Children);
                        }
                    }
                }

                AddNodes(ul, root);

                // Save navigation snippet
                string navPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + "_nav.html");
                navDoc.Save(navPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Helper class for outline nodes
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }
}