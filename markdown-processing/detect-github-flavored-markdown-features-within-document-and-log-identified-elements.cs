// Detect GitHub Flavored Markdown features within a document and log identified elements.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample GitHub Flavored Markdown content
            string markdown = "# Sample\n\n- [x] Task 1\n- [ ] Task 2\n\n| Header1 | Header2 |\n|---|---|\n| Cell1 | Cell2 |\n\n~~strikethrough~~\n";

            // Convert Markdown to HTMLDocument
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

            // Save the resulting HTML
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("HTML saved at " + outputPath);

            // Detect tables
            var tables = document.QuerySelectorAll("table");
            Console.WriteLine("Tables found: " + tables.Length);

            // Detect task list checkboxes
            var checkboxes = document.QuerySelectorAll("input[type=checkbox]");
            Console.WriteLine("Task list items found: " + checkboxes.Length);

            // Detect strikethrough elements
            var strike = document.QuerySelectorAll("del, s");
            Console.WriteLine("Strikethrough elements found: " + strike.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}