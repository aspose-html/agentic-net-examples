// Create a reusable method that adds missing alt attributes to images across multiple HTML files.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string[] inputFiles = { "sample1.html", "sample2.html" };
            string[] outputFiles = { "output1.html", "output2.html" };

            string htmlContent1 = @"<!DOCTYPE html><html><head><title>Sample 1</title></head><body><img src='image1.png'><p>Text</p></body></html>";
            string htmlContent2 = @"<!DOCTYPE html><html><head><title>Sample 2</title></head><body><img src='image2.png' alt='Existing Alt'><img src='image3.png'></body></html>";

            File.WriteAllText(inputFiles[0], htmlContent1);
            File.WriteAllText(inputFiles[1], htmlContent2);

            // Process each file
            for (int i = 0; i < inputFiles.Length; i++)
            {
                AddMissingAltAttributes(inputFiles[i], outputFiles[i]);
                Console.WriteLine($"Processed '{inputFiles[i]}' and saved to '{outputFiles[i]}'");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AddMissingAltAttributes(string inputPath, string outputPath)
    {
        // Load the HTML document from file
        var document = new Aspose.Html.HTMLDocument(inputPath);

        // Get all <img> elements
        Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

        // Iterate and set missing alt attributes
        foreach (Aspose.Html.Dom.Element node in images)
        {
            var img = node as Aspose.Html.HTMLImageElement;
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
    }
}