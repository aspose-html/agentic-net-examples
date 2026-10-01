// Convert HTML files to JPEG by monitoring a folder and processing new files automatically.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";

            // Ensure folders exist
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exists
            string sampleFilePath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(sampleFilePath))
            {
                System.IO.File.WriteAllText(sampleFilePath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Track processed files to avoid duplicate conversion
            HashSet<string> processedFiles = new HashSet<string>();

            // Bounded polling loop (e.g., 5 iterations)
            for (int iteration = 0; iteration < 5; iteration++)
            {
                // Get all HTML files in the input folder
                string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");

                foreach (string htmlPath in htmlFiles)
                {
                    if (!processedFiles.Contains(htmlPath))
                    {
                        // Load HTML document
                        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                        {
                            // Configure JPEG output options
                            Aspose.Html.Saving.ImageSaveOptions options =
                                new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                            // Determine output image path
                            string outputPath = System.IO.Path.Combine(
                                outputFolder,
                                System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                            // Convert HTML to JPEG
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        }

                        // Mark file as processed
                        processedFiles.Add(htmlPath);
                    }
                }

                // Short pause before next poll
                System.Threading.Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}