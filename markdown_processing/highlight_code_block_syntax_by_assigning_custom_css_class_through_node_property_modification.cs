// Highlight code block syntax by assigning a custom CSS class through node property modification.

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
            // Paths to the source and destination HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all <code> elements (or any other selector for code blocks)
            NodeList codeElements = document.QuerySelectorAll("code");

            // Assign a custom CSS class to each code block
            foreach (HTMLElement element in codeElements)
            {
                element.SetAttribute("class", "custom-highlight");
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}