// Extract all list items from the document and write them to a separate Markdown file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample markdown input
            string sourcePath = "input.md";
            string markdownContent = "# Sample List\n\n- Item One\n- Item Two\n- Item Three\n";
            File.WriteAllText(sourcePath, markdownContent);

            // Load markdown as HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Extract list items
            var listItems = document.QuerySelectorAll("li");
            string result = "";
            foreach (var node in listItems)
            {
                var element = node as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    result += "- " + element.TextContent + Environment.NewLine;
                }
            }

            // Save extracted items to a new markdown file
            string savePath = "list_items.md";
            File.WriteAllText(savePath, result);

            Console.WriteLine("Extraction completed. List items saved to " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}