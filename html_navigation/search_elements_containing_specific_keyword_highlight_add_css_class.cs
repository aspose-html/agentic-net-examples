// Search for elements containing a specific keyword and highlight them by adding a CSS class.

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
            string keyword = "Aspose";
            string highlightClass = "highlight";

            HTMLDocument document = new HTMLDocument(inputPath);
            var allElements = document.GetElementsByTagName("*");

            foreach (Element element in allElements)
            {
                if (!string.IsNullOrEmpty(element.InnerHTML) && element.InnerHTML.Contains(keyword))
                {
                    string existingClass = element.GetAttribute("class");
                    string newClass = string.IsNullOrEmpty(existingClass) ? highlightClass : existingClass + " " + highlightClass;
                    element.SetAttribute("class", newClass);
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}