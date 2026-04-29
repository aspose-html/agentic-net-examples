// Add missing alt text to images lacking descriptions by inserting a default placeholder.

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
            // Input and output HTML file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through each element
            foreach (Element node in images)
            {
                // Cast to HTMLImageElement
                HTMLImageElement img = node as HTMLImageElement;
                if (img != null)
                {
                    // Read current alt attribute
                    string alt = img.GetAttribute("alt");
                    // If alt is missing or empty, set a default placeholder
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
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