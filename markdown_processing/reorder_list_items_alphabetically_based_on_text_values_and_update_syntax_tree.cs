// Reorder list items alphabetically based on their text values and update the syntax tree.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Select all ordered and unordered lists
                var listNodes = document.QuerySelectorAll("ul, ol");
                for (int i = 0; i < listNodes.Length; i++)
                {
                    var listElement = (HTMLElement)listNodes[i];

                    // Gather all <li> elements within the current list
                    var liNodes = listElement.QuerySelectorAll("li");
                    var liElements = new System.Collections.Generic.List<HTMLElement>();
                    for (int j = 0; j < liNodes.Length; j++)
                    {
                        liElements.Add((HTMLElement)liNodes[j]);
                    }

                    // Sort the <li> elements alphabetically by their trimmed text content (case‑insensitive)
                    liElements.Sort((a, b) =>
                        string.Compare(a.TextContent.Trim(), b.TextContent.Trim(),
                                        StringComparison.OrdinalIgnoreCase));

                    // Remove existing <li> children from the list
                    foreach (var li in liElements)
                    {
                        listElement.RemoveChild(li);
                    }

                    // Append the sorted <li> elements back to the list
                    foreach (var li in liElements)
                    {
                        listElement.AppendChild(li);
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}