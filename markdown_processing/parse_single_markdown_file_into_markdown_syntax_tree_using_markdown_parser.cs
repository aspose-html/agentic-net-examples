// Parse a single Markdown file into a MarkdownSyntaxTree using the MarkdownParser class.

using System;
using Aspose.Html.Toolkit.Markdown.Syntax.Parser;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "sample.md";
            var parser = new MarkdownParser();
            var syntaxTree = parser.ParseFile(markdownPath);
            Console.WriteLine("Markdown file parsed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}