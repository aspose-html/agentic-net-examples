// Delete a specific list item identified by its text content from a Markdown list.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.html";
            string targetText = "Item to delete";

            // Convert Markdown file to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath);

            // Find all list item elements
            NodeList listItems = document.QuerySelectorAll("li");
            for (int i = 0; i < listItems.Length; i++)
            {
                HTMLElement li = listItems[i] as HTMLElement;
                if (li != null && li.TextContent != null && li.TextContent.Trim() == targetText)
                {
                    // Remove the matching list item from its parent
                    li.ParentNode.RemoveChild(li);
                    // Assuming only one match; break if desired
                    break;
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}