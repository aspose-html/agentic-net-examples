// Extract all heading elements and assign incremental IDs for anchor linking within the document.

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
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the modified HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document
            using HTMLDocument document = new HTMLDocument(inputPath);

            int counter = 1;
            // List of heading tags to process
            string[] headingTags = new[] { "h1", "h2", "h3", "h4", "h5", "h6" };

            // Iterate over each heading tag type
            foreach (string tag in headingTags)
            {
                // Get all elements of the current heading tag
                HTMLCollection headings = document.GetElementsByTagName(tag);
                // Loop through the collection and assign incremental IDs
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement heading = headings[i] as HTMLElement;
                    if (heading != null)
                    {
                        heading.Id = $"heading-{counter}";
                        counter++;
                    }
                }
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