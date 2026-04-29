// Serialize the modified MarkdownSyntaxTree to a string with custom indentation for readability.

using System;
using System.Text;
using Aspose.Html; // Placeholder namespace for Markdown syntax tree types

class Program
{
    static void Main()
    {
        try
        {
            // Create or load a MarkdownSyntaxTree (replace with actual loading logic if needed)
            var markdownTree = new MarkdownSyntaxTree();

            // Example modification: add a heading node (replace with real API calls)
            var heading = new MarkdownSyntaxNode("Heading", "## Sample Heading");
            markdownTree.Root.AddChild(heading);

            // Serialize the tree with custom indentation (2 spaces per level)
            string serialized = SerializeMarkdownTree(markdownTree, "  ");
            Console.WriteLine(serialized);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    // Serializes a MarkdownSyntaxTree to a formatted string using the specified indentation string
    static string SerializeMarkdownTree(MarkdownSyntaxTree tree, string indentation)
    {
        var sb = new StringBuilder();
        SerializeNode(tree.Root, sb, 0, indentation);
        return sb.ToString();
    }

    // Recursively writes a node and its children with proper indentation
    static void SerializeNode(MarkdownSyntaxNode node, StringBuilder sb, int depth, string indentation)
    {
        string indent = new string(' ', depth * indentation.Length);
        sb.AppendLine($"{indent}{node.Type}: {node.Content}");

        foreach (var child in node.Children)
        {
            SerializeNode(child, sb, depth + 1, indentation);
        }
    }
}

// Placeholder classes to represent the Markdown syntax tree structure.
// Replace these with the actual Aspose.Html classes when available.
namespace Aspose.Html
{
    public class MarkdownSyntaxTree
    {
        public MarkdownSyntaxNode Root { get; } = new MarkdownSyntaxNode("Document", string.Empty);
    }

    public class MarkdownSyntaxNode
    {
        public string Type { get; }
        public string Content { get; }
        public System.Collections.Generic.List<MarkdownSyntaxNode> Children { get; } = new System.Collections.Generic.List<MarkdownSyntaxNode>();

        public MarkdownSyntaxNode(string type, string content)
        {
            Type = type;
            Content = content;
        }

        public void AddChild(MarkdownSyntaxNode child) => Children.Add(child);
    }
}