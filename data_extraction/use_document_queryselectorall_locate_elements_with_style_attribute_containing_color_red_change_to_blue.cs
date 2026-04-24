// Use Document.QuerySelectorAll to locate all elements with style attribute containing "color:red" and change to blue.

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
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the modified HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all elements whose style attribute contains "color:red"
            NodeList elements = document.QuerySelectorAll("[style*='color:red']");

            // Change the text color to blue for each matched element
            foreach (HTMLElement element in elements)
            {
                element.Style.Color = "blue";
            }

            // Save the updated document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}