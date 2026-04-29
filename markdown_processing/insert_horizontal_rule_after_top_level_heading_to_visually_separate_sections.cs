// Insert a horizontal rule after every top‑level heading to visually separate sections.

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

            HTMLDocument document = new HTMLDocument(inputPath);

            var headings = document.QuerySelectorAll("h1");
            for (int i = 0; i < headings.Length; i++)
            {
                HTMLElement heading = (HTMLElement)headings[i];
                Element hr = document.CreateElement("hr");
                var parent = heading.ParentNode;
                var next = heading.NextSibling;
                if (next != null)
                {
                    parent.InsertBefore(hr, next);
                }
                else
                {
                    parent.AppendChild(hr);
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}