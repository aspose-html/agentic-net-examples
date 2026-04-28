// Wrap each paragraph element inside a div with a specific CSS class for layout control.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output HTML file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all paragraph elements
            var paragraphs = document.GetElementsByTagName("p");

            // Iterate over a snapshot of the collection to avoid modification issues
            foreach (Element paragraph in paragraphs)
            {
                // Create a new div element
                Element wrapperDiv = document.CreateElement("div");
                // Assign the desired CSS class for layout control
                wrapperDiv.SetAttribute("class", "layout");

                // Replace the paragraph with the new div in the DOM
                var parent = paragraph.ParentNode;
                parent.ReplaceChild(wrapperDiv, paragraph);
                // Append the original paragraph inside the div
                wrapperDiv.AppendChild(paragraph);
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