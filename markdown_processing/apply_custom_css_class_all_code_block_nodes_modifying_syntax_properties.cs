// Apply a custom CSS class to all code block nodes by modifying their syntax properties.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);
            NodeList elements = document.QuerySelectorAll("code, pre");

            foreach (HTMLElement element in elements)
            {
                element.SetAttribute("class", "custom-code");
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}