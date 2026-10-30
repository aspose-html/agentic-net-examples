// Delete a specific list item identified by its text content from a Markdown list.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.md";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleMarkdown = "# Sample List\n\n- Item 1\n- Item 2\n- Item 3\n";
                File.WriteAllText(inputPath, sampleMarkdown);
            }

            // Load the markdown document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Find all list items (<li>) and remove the one with specific text
            HTMLCollection listItems = document.GetElementsByTagName("li");
            for (int i = listItems.Length - 1; i >= 0; i--)
            {
                Element li = (Element)listItems[i];
                if (li.TextContent != null && li.TextContent.Trim() == "Item 2")
                {
                    if (li.ParentNode != null)
                    {
                        li.ParentNode.RemoveChild(li);
                    }
                }
            }

            // Save the modified document back to markdown
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}