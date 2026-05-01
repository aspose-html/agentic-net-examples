// Batch process a directory of HTML files to add alt text and save each modified file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace BatchAltTextAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output folders
                string inputFolder = @"C:\HtmlInput";
                string outputFolder = @"C:\HtmlOutput";

                // Ensure the output folder exists
                Directory.CreateDirectory(outputFolder);

                // Process each HTML file in the input folder
                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    // Load the HTML document
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // Get all <img> elements
                        HTMLCollection images = document.GetElementsByTagName("img");

                        // Iterate over each element
                        foreach (Element node in images)
                        {
                            HTMLImageElement img = node as HTMLImageElement;
                            if (img != null)
                            {
                                // Read current alt attribute
                                string alt = img.GetAttribute("alt");
                                if (string.IsNullOrWhiteSpace(alt))
                                {
                                    // Generate a simple alt text based on the image source filename
                                    string src = img.GetAttribute("src");
                                    string fileName = Path.GetFileNameWithoutExtension(src ?? string.Empty);
                                    string autoAlt = string.IsNullOrEmpty(fileName) ? "Image" : $"Image of {fileName}";
                                    img.SetAttribute("alt", autoAlt);
                                }
                            }
                        }

                        // Save the modified document to the output folder
                        string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                        document.Save(outputPath);
                    }
                }

                Console.WriteLine("Processing completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}