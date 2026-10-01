// Detect GitHub Flavored Markdown features within a document and log identified elements.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample GFM\n\n- [x] Completed task\n- [ ] Incomplete task\n\n~~Strikethrough text~~\n\n| Header1 | Header2 |\n|---------|---------|\n| Cell1   | Cell2   |\n";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");

            var tables = document.QuerySelectorAll("table");
            var checkboxes = document.QuerySelectorAll("input[type=checkbox]");
            var delElements = document.QuerySelectorAll("del");

            Console.WriteLine($"Tables detected: {tables.Length}");
            Console.WriteLine($"Task list items detected: {checkboxes.Length}");
            Console.WriteLine($"Strikethrough elements detected: {delElements.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}