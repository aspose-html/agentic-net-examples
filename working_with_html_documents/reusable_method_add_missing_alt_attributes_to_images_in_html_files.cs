// Create a reusable method that adds missing alt attributes to images across multiple HTML files.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <inputFolder> <outputFolder>");
                return;
            }

            string inputFolder = args[0];
            string outputFolder = args[1];

            if (!Directory.Exists(inputFolder))
                throw new DirectoryNotFoundException($"Input folder not found: {inputFolder}");

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string filePath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string fileName = Path.GetFileName(filePath);
                string outputPath = Path.Combine(outputFolder, fileName);
                AddMissingAltAttributes(filePath, outputPath);
                Console.WriteLine($"Processed: {fileName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AddMissingAltAttributes(string inputPath, string outputPath)
    {
        // Load the HTML document
        HTMLDocument document = new HTMLDocument(inputPath);

        // Get all img elements
        HTMLCollection images = document.GetElementsByTagName("img");

        // Iterate through each element
        foreach (Element node in images)
        {
            HTMLImageElement img = node as HTMLImageElement;
            if (img != null)
            {
                string alt = img.GetAttribute("alt");
                if (string.IsNullOrWhiteSpace(alt))
                {
                    string src = img.GetAttribute("src");
                    string autoAlt = "Image";

                    if (!string.IsNullOrWhiteSpace(src))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(src);
                        if (!string.IsNullOrWhiteSpace(fileName))
                            autoAlt = fileName;
                    }

                    img.SetAttribute("alt", autoAlt);
                }
            }
        }

        // Save the modified document
        document.Save(outputPath);
    }
}