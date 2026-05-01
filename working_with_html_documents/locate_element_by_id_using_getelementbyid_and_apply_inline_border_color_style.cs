// Locate an element by ID with GetElementById and apply an inline border-color style.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Css;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // ID of the element to modify
                string elementId = "myElement";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Locate the element by its ID
                HTMLElement element = document.GetElementById(elementId) as HTMLElement;

                if (element != null)
                {
                    // Apply an inline border-color style
                    element.Style.BorderColor = "red";
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