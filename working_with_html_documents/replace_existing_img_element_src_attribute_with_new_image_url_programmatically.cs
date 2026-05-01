// Replace an existing img element’s src attribute with a new image URL programmatically.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the modified HTML will be saved
            string outputPath = "output.html";
            // New image URL to set for img elements
            string newImageUrl = "https://example.com/newimage.png";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Get all <img> elements in the document
                HTMLCollection images = document.GetElementsByTagName("img");

                // Replace the src attribute of each img element
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    imgElement.SetAttribute("src", newImageUrl);
                }

                // Save the modified document
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}