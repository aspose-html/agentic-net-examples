// Prefix each heading with a sequential numeric index to create an ordered document outline.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace AsposeHtmlOutlineExample
{
    // 1. Outline node definition
    public class OutlineNode
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public List<OutlineNode> Children { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                // 2. Define input and output folders
                string inputFolder = "InputHtml";
                string outputFolder = "OutputJson";

                if (!Directory.Exists(inputFolder))
                    Directory.CreateDirectory(inputFolder);
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // 3. Create a sample HTML file if none exist
                string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
                if (!File.Exists(sampleHtmlPath))
                {
                    // 3.1 Create HTML document
                    Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

                    // 3.2 Get body
                    Aspose.Html.HTMLElement body = doc.Body;

                    // 3.3 Create H1
                    Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
                    h1.SetAttribute("id", "title");
                    h1.AppendChild(doc.CreateTextNode("Sample Document"));
                    body.AppendChild(h1);

                    // 3.4 Create H2
                    Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
                    h2.SetAttribute("class", "section");
                    h2.AppendChild(doc.CreateTextNode("Introduction"));
                    body.AppendChild(h2);

                    // 3.5 Create unordered list with links
                    Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

                    Aspose.Html.HTMLElement li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                    Aspose.Html.HTMLAnchorElement a1 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
                    a1.SetAttribute("href", "https://example.com/page1");
                    a1.AppendChild(doc.CreateTextNode("Page 1"));
                    li1.AppendChild(a1);
                    ul.AppendChild(li1);

                    Aspose.Html.HTMLElement li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
                    Aspose.Html.HTMLAnchorElement a2 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
                    a2.SetAttribute("href", "https://example.com/page2");
                    a2.AppendChild(doc.CreateTextNode("Page 2"));
                    li2.AppendChild(a2);
                    ul.AppendChild(li2);

                    // 3.6 Insert list before first child of body
                    var firstChild = body.FirstChild;
                    if (firstChild != null)
                        body.InsertBefore(ul, firstChild);
                    else
                        body.AppendChild(ul);

                    // 3.7 Save sample HTML
                    doc.Save(sampleHtmlPath);
                }

                // 4. Process each HTML file to generate outline JSON
                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    // 4.1 Load document
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                    // 4.2 Select all heading elements (h1-h6)
                    var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                    // 4.3 Prepare outline structures
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

                    // 4.4 Serialize to JSON
                    string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });

                    // 4.5 Write JSON file
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
}