// Convert an unordered list of items into an ordered list while preserving list hierarchy.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"
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

            // Load HTML from string using two‑argument constructor
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Collect all <ul> elements
            Aspose.Html.Collections.NodeList ulNodes = document.QuerySelectorAll("ul");
            var ulElements = new List<Aspose.Html.HTMLElement>();
            foreach (Aspose.Html.Dom.Node node in ulNodes)
            {
                ulElements.Add((Aspose.Html.HTMLElement)node);
            }

            // Convert each <ul> to <ol> preserving hierarchy
            foreach (Aspose.Html.HTMLElement ul in ulElements)
            {
                Aspose.Html.HTMLElement ol = (Aspose.Html.HTMLElement)document.CreateElement("ol");

                while (ul.FirstChild != null)
                {
                    Aspose.Html.Dom.Node child = ul.FirstChild;
                    ul.RemoveChild(child);
                    ol.AppendChild(child);
                }

                Aspose.Html.Dom.Node parent = ul.ParentNode;
                parent.ReplaceChild(ol, ul);
            }

            // Ensure output directory exists
            string outputFolder = "Output";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Save the modified HTML to a file
            string outputPath = Path.Combine(outputFolder, "converted.html");
            File.WriteAllText(outputPath, document.DocumentElement.OuterHTML);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}