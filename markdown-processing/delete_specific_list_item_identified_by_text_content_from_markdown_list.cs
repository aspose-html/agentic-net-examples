// Delete a specific list item identified by its text content from a Markdown list.

using System;

namespace DeleteMarkdownListItem
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.md";
                string outputPath = "output.md";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "- Item 1\n- Item to delete\n- Item 3");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.Collections.HTMLCollection listItems = document.GetElementsByTagName("li");

                for (int i = listItems.Length - 1; i >= 0; i--)
                {
                    Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)listItems[i];
                    if (li.TextContent != null && li.TextContent.Trim() == "Item to delete")
                    {
                        if (li.ParentNode != null)
                        {
                            li.ParentNode.RemoveChild(li);
                        }
                    }
                }

                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}