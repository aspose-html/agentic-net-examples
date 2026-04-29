// Prefix each heading with a sequential numeric index to create an ordered document outline.

using System;
using Aspose.Html;

namespace HeadingIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input HTML file path
                string inputPath = "input.html";
                // Output HTML file path
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Select all heading elements (h1 to h6)
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                // Prefix each heading with a sequential number
                for (int i = 0; i < headings.Length; i++)
                {
                    // Cast to HTMLElement to access TextContent
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)headings[i];
                    // Trim existing text and add numeric prefix
                    element.TextContent = $"{i + 1}. {element.TextContent.Trim()}";
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
}