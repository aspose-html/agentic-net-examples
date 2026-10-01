// Generate descriptive alt text from image filenames for images lacking alt attributes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<img src='image1.png'>" +
                                    "<img src='image2.png' alt='Existing alt'>" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Add missing alt attributes
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}