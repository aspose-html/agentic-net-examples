// Detect and fix inconsistent indentation in nested lists to ensure proper hierarchical rendering.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the corrected HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document from the file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all list item elements in the document
            var listItems = document.QuerySelectorAll("li");

            // Iterate over each list item and normalize its text indentation
            foreach (HTMLElement item in listItems)
            {
                // Trim leading and trailing whitespace from the text content
                string cleanedText = item.TextContent.Trim();
                item.TextContent = cleanedText;
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}