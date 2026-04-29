// Compare two MarkdownSyntaxTree objects for structural equality to detect unintended modifications during version control.

using System;
using Aspose.Html.Toolkit.Markdown.Syntax;
using Aspose.Html.Toolkit.Markdown.Syntax.Parser;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide two markdown file paths as arguments.");
                return;
            }

            string firstPath = args[0];
            string secondPath = args[1];

            var parser = new MarkdownParser();

            MarkdownSyntaxTree firstTree = parser.ParseFile(firstPath);
            MarkdownSyntaxTree secondTree = parser.ParseFile(secondPath);

            bool treesAreEqual = firstTree.ToString() == secondTree.ToString();

            Console.WriteLine(treesAreEqual
                ? "The Markdown syntax trees are identical."
                : "The Markdown syntax trees differ.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}