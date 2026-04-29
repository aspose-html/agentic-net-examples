// Load all .md files from a directory and parse each into separate syntax trees.

using System;
using System.IO;
using Aspose.Html.Toolkit.Markdown.Syntax.Parser;
using Aspose.Html.Toolkit.Markdown.Syntax;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "path_to_md_folder";
            if (!Directory.Exists(inputFolder))
                return;
            var parser = new MarkdownParser();
            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                MarkdownSyntaxTree tree = parser.ParseFile(mdPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}