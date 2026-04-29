// Convert tabs to spaces within code blocks to maintain consistent formatting across editors.

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
            var codeElements = document.QuerySelectorAll("pre code");
            foreach (Element element in codeElements)
            {
                string text = element.TextContent;
                string replaced = text.Replace("\t", "    ");
                element.TextContent = replaced;
            }
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}