// Count the number of headings at each level and output the statistics as a comment.

using System;

public class OutlineNode
{
    public string Text { get; set; }
    public int Level { get; set; }
    public System.Collections.Generic.List<OutlineNode> Children { get; set; }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "Output";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                var root = new System.Collections.Generic.List<OutlineNode>();
                var stack = new System.Collections.Generic.Stack<OutlineNode>();
                var counts = new System.Collections.Generic.Dictionary<int, int>();

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

                    if (!counts.ContainsKey(level))
                        counts[level] = 0;
                    counts[level]++;
                }

                // Create comment with heading statistics
                string commentText = "Heading counts: ";
                foreach (var kvp in counts)
                {
                    commentText += $"h{kvp.Key}={kvp.Value} ";
                }
                commentText = commentText.Trim();

                var commentNode = document.CreateComment(commentText);
                document.InsertBefore(commentNode, document.DocumentElement);

                // Save modified HTML
                string htmlOutputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileName(htmlPath));
                document.Save(htmlOutputPath);

                // Save outline as JSON
                string json = System.Text.Json.JsonSerializer.Serialize(root, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                string jsonPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".json");
                System.IO.File.WriteAllText(jsonPath, json);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}