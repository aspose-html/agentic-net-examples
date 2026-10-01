// Extract all list items from the document and write them to a separate Markdown file.

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
            // Input markdown file
            string sourcePath = "input.md";
            if (!File.Exists(sourcePath))
            {
                string sampleMarkdown = "# Sample List\n\n- First item\n- Second item\n- Third item";
                File.WriteAllText(sourcePath, sampleMarkdown);
            }

            // Convert markdown to HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Extract all list items
            var listItems = document.QuerySelectorAll("li");
            StringBuilder sb = new StringBuilder();

            foreach (var node in listItems)
            {
                Aspose.Html.HTMLElement li = node as Aspose.Html.HTMLElement;
                if (li != null)
                {
                    sb.AppendLine("- " + li.TextContent.Trim());
                }
            }

            // Output markdown file with extracted items
            string savePath = "list_items.md";
            File.WriteAllText(savePath, sb.ToString());

            Console.WriteLine("Extraction completed. List items saved to " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}