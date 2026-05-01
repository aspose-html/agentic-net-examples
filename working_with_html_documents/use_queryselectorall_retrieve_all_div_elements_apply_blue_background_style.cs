// Use QuerySelectorAll to retrieve all <div> elements and apply a blue background style.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            HTMLDocument document = new HTMLDocument("input.html");

            // Retrieve all <div> elements in the document
            var divElements = document.QuerySelectorAll("div");

            // Apply a blue background color to each <div>
            foreach (HTMLElement element in divElements)
            {
                element.Style.BackgroundColor = "blue";
            }

            // Save the modified document (optional)
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}