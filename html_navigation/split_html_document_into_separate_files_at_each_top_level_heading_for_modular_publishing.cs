// Split an HTML document into separate files at each top‑level heading for modular publishing.

using System;
using System.IO;
using System.Text;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1");
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement heading = (HTMLElement)headings[i];
                    StringBuilder bodyContent = new StringBuilder();
                    bodyContent.AppendLine(heading.OuterHTML);
                    var sibling = heading.NextSibling;
                    while (sibling != null && !(sibling is HTMLElement elem && elem.TagName.Equals("h1", StringComparison.OrdinalIgnoreCase)))
                    {
                        if (sibling is HTMLElement htmlElem)
                            bodyContent.AppendLine(htmlElem.OuterHTML);
                        sibling = sibling.NextSibling;
                    }
                    HTMLDocument partDoc = new HTMLDocument();
                    partDoc.Body.InnerHTML = bodyContent.ToString();
                    string fileName = Path.GetFileNameWithoutExtension(htmlPath) + $"_section{i + 1}.html";
                    string outPath = Path.Combine(outputFolder, fileName);
                    partDoc.Save(outPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}