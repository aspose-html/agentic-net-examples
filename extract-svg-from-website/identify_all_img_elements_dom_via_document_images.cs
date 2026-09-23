// Identify all <img> elements in the DOM via document.Images.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content containing <img> elements
            string htmlContent = "<html><body><img src='image1.png'/><p>Sample text</p><img src='image2.jpg'/></body></html>";
            string inputFile = "sample.html";

            // Write the sample HTML to a file
            File.WriteAllText(inputFile, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputFile))
            {
                // Get all <img> elements via the Images collection
                Aspose.Html.Collections.HTMLCollection images = document.Images;

                Console.WriteLine($"Found {images.Length} <img> element(s) in the document.");

                foreach (Aspose.Html.Dom.Element img in images)
                {
                    // Retrieve the 'src' attribute of each image
                    string src = img.GetAttribute("src");
                    Console.WriteLine($"Image src: {src}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}