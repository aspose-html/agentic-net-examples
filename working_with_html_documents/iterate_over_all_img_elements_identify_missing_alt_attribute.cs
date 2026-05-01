// Iterate over all <img> elements and identify those missing an alt attribute.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the input HTML file
            string inputPath = "input.html";
            // Path to the output HTML file (saved after processing)
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Retrieve all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through each element
            foreach (Aspose.Html.Dom.Element node in images)
            {
                // Cast to HTMLImageElement to access image-specific properties
                HTMLImageElement img = node as HTMLImageElement;
                if (img != null)
                {
                    // Get the current alt attribute value
                    string alt = img.GetAttribute("alt");
                    // Identify images missing an alt attribute
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        Console.WriteLine($"Image missing alt attribute. Src: {img.Src}");
                    }
                }
            }

            // Save the (potentially modified) document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}