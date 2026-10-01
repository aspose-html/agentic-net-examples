// Convert an unordered list of items into an ordered list while preserving list hierarchy.

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
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string samplePath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(samplePath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<ul>
    <li>Item 1</li>
    <li>Item 2
        <ul>
            <li>Subitem 2.1</li>
            <li>Subitem 2.2</li>
        </ul>
    </li>
    <li>Item 3</li>
</ul>
</body>
</html>";
                File.WriteAllText(samplePath, sampleHtml);
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);
                NodeList uls = document.QuerySelectorAll("ul");

                for (int i = 0; i < uls.Length; i++)
                {
                    HTMLElement ul = (HTMLElement)uls[i];
                    HTMLElement ol = (HTMLElement)document.CreateElement("ol");

                    // Move all child nodes from ul to ol
                    while (ul.FirstChild != null)
                    {
                        Node child = ul.FirstChild;
                        ul.RemoveChild(child);
                        ol.AppendChild(child);
                    }

                    // Replace ul with ol in the DOM
                    ul.ParentNode.ReplaceChild(ol, ul);
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