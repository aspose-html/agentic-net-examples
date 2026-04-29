// Convert an unordered list of items into an ordered list while preserving list hierarchy.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace ListConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output HTML file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Select all unordered list (<ul>) elements
                var ulElements = document.QuerySelectorAll("ul");

                // Replace each <ul> with an <ol> while preserving its inner HTML
                for (int i = 0; i < ulElements.Length; i++)
                {
                    HTMLElement ul = (HTMLElement)ulElements[i];
                    HTMLOListElement ol = (HTMLOListElement)document.CreateElement("ol");
                    ol.InnerHTML = ul.InnerHTML;
                    ul.ParentNode.ReplaceChild(ol, ul);
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