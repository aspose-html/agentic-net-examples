// Renumber an ordered list after deleting items to maintain proper numeric ordering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><body><ol><li>Item 1</li><li>Item 2</li><li>Item 3</li><li>Item 4</li></ol></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove list items that contain "Item 2"
            Aspose.Html.Collections.HTMLCollection listItems = document.GetElementsByTagName("li");
            for (int i = listItems.Length - 1; i >= 0; i--)
            {
                var li = (Aspose.Html.Dom.Element)listItems[i];
                if (li.TextContent != null && li.TextContent.Contains("Item 2"))
                {
                    li.ParentNode.RemoveChild(li);
                }
            }

            // Renumber ordered lists
            Aspose.Html.Collections.HTMLCollection orderedLists = document.GetElementsByTagName("ol");
            for (int i = 0; i < orderedLists.Length; i++)
            {
                var ol = (Aspose.Html.Dom.Element)orderedLists[i];
                int index = 1;
                var child = ol.FirstChild;
                while (child != null)
                {
                    var next = child.NextSibling;
                    if (child.NodeName == "li")
                    {
                        var li = (Aspose.Html.HTMLElement)child;
                        li.SetAttribute("value", index.ToString());
                        index++;
                    }
                    child = next;
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}