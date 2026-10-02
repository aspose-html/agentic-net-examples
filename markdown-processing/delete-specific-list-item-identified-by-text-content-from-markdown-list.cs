// Delete a specific list item identified by its text content from a Markdown list.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file with a list if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"/></head><body><ul><li>Apple</li><li>Banana</li><li>Cherry</li></ul></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <li> elements
            HTMLCollection listItems = document.GetElementsByTagName("li");

            // Text of the item to remove
            string targetText = "Banana";

            // Iterate backwards and remove matching item
            for (int i = listItems.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element li = (Aspose.Html.Dom.Element)listItems[i];
                if (li.TextContent == targetText && li.ParentNode != null)
                {
                    li.ParentNode.RemoveChild(li);
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