// Parse a single Markdown file into a MarkdownSyntaxTree using the MarkdownParser class.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "sample.md";
            if (!File.Exists(markdownPath))
            {
                File.WriteAllText(markdownPath, "# Sample Heading\n\nThis is a sample markdown.");
            }

            var config = new Aspose.Html.Configuration();
            var tree = new Aspose.Html.Toolkit.Markdown.Syntax.MarkdownSyntaxTree(config);

            Console.WriteLine("MarkdownSyntaxTree instance created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}