// Generate a navigation sidebar HTML snippet based on extracted heading hierarchy for the site.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;

class Program
{
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; } = new List<OutlineNode>();
    }

    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputSidebar";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Select all heading elements
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                // Build hierarchical outline
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
                        Level = level
                    };

                    while (stack.Count > 0 && stack.Peek().Level >= level)
                        stack.Pop();

                    if (stack.Count == 0)
                        root.Add(node);
                    else
                        stack.Peek().Children.Add(node);

                    stack.Push(node);
                }

                // Generate navigation sidebar HTML
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<nav>");
                GenerateList(root, sb);
                sb.AppendLine("</nav>");

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + "_sidebar.html");
                File.WriteAllText(outputPath, sb.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void GenerateList(List<OutlineNode> nodes, StringBuilder sb)
    {
        if (nodes == null || nodes.Count == 0)
            return;

        sb.AppendLine("<ul>");
        foreach (var node in nodes)
        {
            sb.Append("<li>").Append(WebUtility.HtmlEncode(node.Text));
            if (node.Children != null && node.Children.Count > 0)
            {
                GenerateList(node.Children, sb);
            }
            sb.AppendLine("</li>");
        }
        sb.AppendLine("</ul>");
    }
}