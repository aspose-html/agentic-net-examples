// Extract all list items from the document and write them to a separate Markdown file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string markdownPath = "list_items.md";

            HTMLDocument document = new HTMLDocument(htmlPath);
            var listItems = document.QuerySelectorAll("li");
            List<string> lines = new List<string>();
            foreach (var node in listItems)
            {
                string text = node.TextContent.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    lines.Add("- " + text);
                }
            }
            File.WriteAllLines(markdownPath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}