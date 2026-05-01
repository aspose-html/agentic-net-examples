// Generate descriptive alt text from image filenames for images lacking alt attributes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

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

            // Retrieve all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through each image element
            foreach (Element node in images)
            {
                HTMLImageElement img = node as HTMLImageElement;
                if (img != null)
                {
                    // Get current alt attribute
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        // Generate descriptive alt text from the image filename
                        string autoAlt = Path.GetFileNameWithoutExtension(img.Src);
                        // Set the generated alt attribute
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}