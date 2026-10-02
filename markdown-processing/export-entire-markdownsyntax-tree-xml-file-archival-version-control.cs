// Export the entire MarkdownSyntaxTree to an XML file for archival and version control purposes.

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            System.IO.Directory.CreateDirectory(outputDir);
            string sourcePath = System.IO.Path.Combine(outputDir, "sample.md");
            string markdownContent = "# Sample Title\n\nThis is a sample markdown.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                string xmlPath = System.IO.Path.Combine(outputDir, "markdown_syntax_tree.xml");
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                document.Save(xmlPath, options);
                System.Console.WriteLine("Markdown syntax tree exported to XML at: " + xmlPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}