// Detect GitHub Flavored Markdown features within a document and log identified elements.

using System;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "input.md";

            // Convert Markdown to HTMLDocument for analysis
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Detect tables
            var tables = document.QuerySelectorAll("table");
            Console.WriteLine($"Tables detected: {tables.Length}");

            // Detect task list checkboxes
            var checkboxes = document.QuerySelectorAll("input[type=checkbox]");
            Console.WriteLine($"Task list checkboxes detected: {checkboxes.Length}");

            // Detect strikethrough (del elements)
            var delElements = document.QuerySelectorAll("del");
            Console.WriteLine($"Strikethrough elements detected: {delElements.Length}");

            // Detect code blocks
            var codeBlocks = document.QuerySelectorAll("pre > code");
            Console.WriteLine($"Code blocks detected: {codeBlocks.Length}");

            // Detect headings
            var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
            Console.WriteLine($"Headings detected: {headings.Length}");

            // Detect blockquotes
            var blockquotes = document.QuerySelectorAll("blockquote");
            Console.WriteLine($"Blockquotes detected: {blockquotes.Length}");

            // Detect task lists (list items containing a checkbox)
            var taskListItems = document.QuerySelectorAll("li > input[type=checkbox]");
            Console.WriteLine($"Task list items detected: {taskListItems.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}