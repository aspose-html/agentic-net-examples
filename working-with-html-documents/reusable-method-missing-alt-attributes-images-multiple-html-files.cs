// Create a reusable method that adds missing alt attributes to images across multiple HTML files.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string[] inputFiles = new string[] { "sample1.html", "sample2.html" };
            string[] outputFiles = new string[] { "sample1_updated.html", "sample2_updated.html" };

            // Create minimal sample content if files do not exist
            for (int i = 0; i < inputFiles.Length; i++)
            {
                if (!File.Exists(inputFiles[i]))
                {
                    string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                         "<img src=\"image1.png\">" +
                                         "<img src=\"image2.png\" alt=\"Existing Alt\">" +
                                         "</body></html>";
                    File.WriteAllText(inputFiles[i], htmlContent);
                }
            }

            // Process each file
            for (int i = 0; i < inputFiles.Length; i++)
            {
                AddMissingAltAttributes(inputFiles[i], outputFiles[i]);
                Console.WriteLine($"Processed '{inputFiles[i]}' and saved to '{outputFiles[i]}'");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void AddMissingAltAttributes(string inputPath, string outputPath)
    {
        // Load the HTML document from file
        HTMLDocument document = new HTMLDocument(inputPath);

        // Get all <img> elements
        HTMLCollection images = document.GetElementsByTagName("img");

        // Iterate over each image element
        foreach (Element node in images)
        {
            HTMLImageElement img = node as HTMLImageElement;
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