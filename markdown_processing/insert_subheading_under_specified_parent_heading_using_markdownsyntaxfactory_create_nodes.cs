// Insert a subheading under a specified parent heading using the MarkdownSyntaxFactory to create nodes.

using System;
using Aspose.Html.Toolkit.Markdown.Syntax;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                var tree = new MarkdownSyntaxTree();
                var factory = tree.SyntaxFactory;
                var parentHeading = factory.AtxHeading("Parent Heading", 2);
                var subHeading = factory.AtxHeading("Sub Heading", 3);
                tree.AppendChild(parentHeading);
                parentHeading.AppendChild(subHeading);
                tree.Save("output.md");
                Console.WriteLine("Markdown file created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}