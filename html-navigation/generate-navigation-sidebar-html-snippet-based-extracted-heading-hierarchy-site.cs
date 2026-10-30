// Generate a navigation sidebar HTML snippet based on extracted heading hierarchy for the site.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Net;

class Program
{
    class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }

    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputNav";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Ensure input folder exists and contains at least one sample file
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            string samplePath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath,
@"<html>
<head><title>Sample</title></head>
<body>
<h1>Chapter 1</h1>
<h2>Section 1.1</h2>
<h3>Subsection 1.1.1</h3>
<h2>Section 1.2</h2>
<h1>Chapter 2</h1>
<h2>Section 2.1</h2>
</body>
</html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
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

                string htmlSnippet = GenerateHtmlSnippet(root);
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(htmlPath) + "_nav.html");
                File.WriteAllText(outputPath, htmlSnippet);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string GenerateHtmlSnippet(List<OutlineNode> nodes)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<ul>");
        foreach (var node in nodes)
            AppendNode(sb, node);
        sb.AppendLine("</ul>");
        return sb.ToString();
    }

    static void AppendNode(StringBuilder sb, OutlineNode node)
    {
        sb.AppendLine("<li>" + WebUtility.HtmlEncode(node.Text) + "</li>");
        if (node.Children != null && node.Children.Count > 0)
        {
            sb.AppendLine("<ul>");
            foreach (var child in node.Children)
                AppendNode(sb, child);
            sb.AppendLine("</ul>");
        }
    }
}