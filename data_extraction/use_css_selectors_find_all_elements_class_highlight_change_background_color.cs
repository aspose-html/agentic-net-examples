// Use CSS selectors to find all elements with class "highlight" and change their background color.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
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
            NodeList elements = document.QuerySelectorAll(".highlight");

            foreach (HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "yellow";
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}