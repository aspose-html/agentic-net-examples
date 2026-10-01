// Reorder list items alphabetically based on their text values and update the syntax tree.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Select all <ul> elements
                var ulElements = document.QuerySelectorAll("ul");
                foreach (var ulNode in ulElements)
                {
                    Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)ulNode;

                    // Collect <li> elements
                    var liNodes = ul.QuerySelectorAll("li");
                    List<Aspose.Html.HTMLElement> liList = new List<Aspose.Html.HTMLElement>();
                    foreach (var liNode in liNodes)
                    {
                        liList.Add((Aspose.Html.HTMLElement)liNode);
                    }

                    // Sort list items alphabetically by their trimmed text content
                    liList.Sort((a, b) =>
                        string.Compare(a.TextContent.Trim(), b.TextContent.Trim(), StringComparison.Ordinal));

                    // Remove existing <li> children
                    foreach (var liNode in liNodes)
                    {
                        ul.RemoveChild(liNode);
                    }

                    // Append sorted <li> elements back to the <ul>
                    foreach (var li in liList)
                    {
                        ul.AppendChild(li);
                    }
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + "_sorted.html");
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}