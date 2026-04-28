// Remove all inline style attributes from elements to enforce external stylesheet usage.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source and destination HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document from the source file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all elements that contain an inline style attribute
            var elementsWithStyle = document.QuerySelectorAll("[style]");

            // Remove the inline style attribute from each element
            foreach (Element element in elementsWithStyle)
            {
                element.RemoveAttribute("style");
            }

            // Save the updated document to the destination file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}