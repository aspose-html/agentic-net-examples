// Reorder list items alphabetically based on their text values and update the syntax tree.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                // create a sample HTML file
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><ul><li>Banana</li><li>Apple</li><li>Cherry</li></ul></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);
                Aspose.Html.Collections.NodeList listNodes = document.QuerySelectorAll("ul, ol");
                for (int i = 0; i < listNodes.Length; i++)
                {
                    Element listElement = (Element)listNodes[i];
                    Aspose.Html.Collections.NodeList liNodes = listElement.QuerySelectorAll("li");
                    List<HTMLElement> items = new List<HTMLElement>();
                    for (int j = 0; j < liNodes.Length; j++)
                    {
                        HTMLElement li = (HTMLElement)liNodes[j];
                        items.Add(li);
                    }

                    items.Sort((a, b) => string.Compare(a.TextContent.Trim(), b.TextContent.Trim(), StringComparison.Ordinal));

                    // Remove existing <li> elements
                    foreach (HTMLElement li in items)
                    {
                        listElement.RemoveChild(li);
                    }

                    // Append sorted <li> elements
                    foreach (HTMLElement li in items)
                    {
                        listElement.AppendChild(li);
                    }
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}