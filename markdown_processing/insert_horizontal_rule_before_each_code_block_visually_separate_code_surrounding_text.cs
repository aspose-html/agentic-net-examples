// Insert a horizontal rule before each code block to visually separate code from surrounding text.

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

            var codeElements = document.QuerySelectorAll("pre, code");
            foreach (Element elem in codeElements)
            {
                Element hr = document.CreateElement("hr");
                elem.ParentNode.InsertBefore(hr, elem);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}