// Apply an inline background-color style to a div identified by ID and save the changes.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths and parameters
            string inputPath = "input.html";
            string outputPath = "output.html";
            string divId = "myDiv";
            string backgroundColor = "#ff0000";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Locate the div element by its ID
            HTMLElement div = document.QuerySelector($"#{divId}") as HTMLElement;

            if (div != null)
            {
                // Apply inline background-color style
                div.Style.BackgroundColor = backgroundColor;
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}