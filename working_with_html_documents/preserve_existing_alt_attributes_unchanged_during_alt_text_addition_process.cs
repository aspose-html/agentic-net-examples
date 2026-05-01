// Preserve existing alt attributes unchanged during the alt text addition process.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace AltTextPreserver
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

                // Retrieve all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Iterate through each image element
                foreach (Element node in images)
                {
                    // Cast to HTMLImageElement to access image-specific properties
                    HTMLImageElement img = node as HTMLImageElement;
                    if (img != null)
                    {
                        // Read the current alt attribute
                        string alt = img.GetAttribute("alt");

                        // If alt is missing or empty, generate a descriptive alt text
                        if (string.IsNullOrWhiteSpace(alt))
                        {
                            // Use the image file name (without extension) as the alt text
                            string src = img.GetAttribute("src");
                            string autoAlt = System.IO.Path.GetFileNameWithoutExtension(src);
                            img.SetAttribute("alt", autoAlt);
                        }
                        // Existing alt attributes are left unchanged
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
}