// Apply a red border style to each element returned by the highlight selector.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string highlightSelector = ".highlight";

            HTMLDocument document = new HTMLDocument(inputPath);
            NodeList elements = document.QuerySelectorAll(highlightSelector);
            foreach (HTMLElement element in elements)
            {
                element.Style.BorderStyle = "solid";
                element.Style.BorderColor = "red";
            }
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}