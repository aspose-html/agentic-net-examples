// Batch process a folder of HTML files to change all paragraph text colors to a specified hex value.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

namespace BatchParagraphColorChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Expect three arguments: input folder, output folder, hex color (e.g., "#8b0000")
                if (args.Length != 3)
                {
                    Console.WriteLine("Usage: BatchParagraphColorChanger <inputFolder> <outputFolder> <hexColor>");
                    return;
                }

                string inputFolder = args[0];
                string outputFolder = args[1];
                string hexColor = args[2];

                if (!Directory.Exists(inputFolder))
                {
                    Console.WriteLine($"Input folder does not exist: {inputFolder}");
                    return;
                }

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // Process each HTML file in the input folder
                foreach (string filePath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    // Load the HTML document
                    HTMLDocument document = new HTMLDocument(filePath);

                    // Create a <style> element with CSS that sets paragraph text color
                    Element style = document.CreateElement("style");
                    style.TextContent = $"p {{ color: {hexColor}; }}";

                    // Append the style element to the <head> section
                    Element head = document.GetElementsByTagName("head").First();
                    head.AppendChild(style);

                    // Determine output file path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(filePath));

                    // Save the modified document
                    document.Save(outputPath);
                }

                Console.WriteLine("Batch processing completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}