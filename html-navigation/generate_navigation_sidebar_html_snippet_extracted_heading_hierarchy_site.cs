// Generate a navigation sidebar HTML snippet based on extracted heading hierarchy for the site.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Net;

namespace NavigationSidebarGenerator
{
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
                string inputFolder = "InputHtml";
                string outputFolder = "OutputNav";

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    var document = new Aspose.Html.HTMLDocument(htmlPath);
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

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<nav>");
                    GenerateHtml(root, sb);
                    sb.AppendLine("</nav>");

                    string navPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + "_nav.html");
                    File.WriteAllText(navPath, sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void GenerateHtml(List<OutlineNode> nodes, StringBuilder sb)
        {
            if (nodes == null || nodes.Count == 0)
                return;

            sb.AppendLine("<ul>");
            foreach (var node in nodes)
            {
                sb.Append("<li>");
                sb.Append(WebUtility.HtmlEncode(node.Text));
                if (node.Children != null && node.Children.Count > 0)
                {
                    GenerateHtml(node.Children, sb);
                }
                sb.AppendLine("</li>");
            }
            sb.AppendLine("</ul>");
        }
    }
}