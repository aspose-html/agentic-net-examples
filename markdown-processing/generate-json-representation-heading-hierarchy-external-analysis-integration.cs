// Generate a JSON representation of the heading hierarchy for external analysis or integration.

using System;

class OutlineNode
{
    public string Text { get; set; }
    public int Level { get; set; }
    public System.Collections.Generic.List<OutlineNode> Children { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputJson";

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<html><body><h1>Title</h1><h2>Section</h2><h3>Subsection</h3></body></html>";
                System.IO.File.WriteAllText(samplePath, sampleContent);
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                var root = new System.Collections.Generic.List<OutlineNode>();
                var stack = new System.Collections.Generic.Stack<OutlineNode>();

                for (int i = 0; i < headings.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)headings[i];
                    string tag = element.TagName.ToLower();
                    int level = int.Parse(tag.Substring(1));

                    OutlineNode node = new OutlineNode();
                    node.Text = element.TextContent.Trim();
                    node.Level = level;
                    node.Children = new System.Collections.Generic.List<OutlineNode>();

                    while (stack.Count > 0 && stack.Peek().Level >= level)
                        stack.Pop();

                    if (stack.Count == 0)
                        root.Add(node);
                    else
                        stack.Peek().Children.Add(node);

                    stack.Push(node);
                }

                string json = System.Text.Json.JsonSerializer.Serialize(root, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                string jsonPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                System.IO.File.WriteAllText(jsonPath, json);
            }

            System.Console.WriteLine("Heading hierarchy JSON files have been generated successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}