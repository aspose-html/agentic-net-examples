// Detect and remove empty style tags that contain no CSS rules in the document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace RemoveEmptyStyleTags
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

                // Get all <style> elements in the document
                var styleElements = document.GetElementsByTagName("style");

                // Iterate through the collection in reverse order to safely remove nodes
                for (int i = styleElements.Length - 1; i >= 0; i--)
                {
                    // Cast the node to Element
                    Element styleElement = (Element)styleElements[i];

                    // Check if the style element has no CSS rules (empty or whitespace)
                    if (string.IsNullOrWhiteSpace(styleElement.TextContent))
                    {
                        // Remove the empty style element from its parent
                        if (styleElement.ParentNode != null)
                        {
                            styleElement.ParentNode.RemoveChild(styleElement);
                        }
                    }
                }

                // Save the modified document
                document.Save(outputPath);

                // Clean up
                document.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}