// Replace all <b> tags with <strong> tags to improve semantic markup throughout the document.

using System;
using System.Collections.Generic;
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

            HTMLDocument document = new HTMLDocument(inputPath);

            var boldCollection = document.GetElementsByTagName("b");
            var boldList = new List<HTMLElement>();
            foreach (var node in boldCollection)
            {
                boldList.Add((HTMLElement)node);
            }

            foreach (var b in boldList)
            {
                HTMLElement strong = (HTMLElement)document.CreateElement("strong");
                while (b.FirstChild != null)
                {
                    strong.AppendChild(b.FirstChild);
                }
                var parent = b.ParentNode;
                parent.ReplaceChild(strong, b);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}