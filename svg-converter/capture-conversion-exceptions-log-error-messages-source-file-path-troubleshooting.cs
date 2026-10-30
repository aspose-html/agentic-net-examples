// Capture conversion exceptions and log error messages with source file path for troubleshooting.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string sampleFile = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleFile))
            {
                File.WriteAllText(sampleFile, "<!DOCTYPE html><html><body><h1>Hello, Aspose!</h1></body></html>");
            }

            HashSet<string> processedFiles = new HashSet<string>();

            for (int iteration = 0; iteration < 5; iteration++)
            {
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
                foreach (string htmlPath in htmlFiles)
                {
                    if (processedFiles.Contains(htmlPath))
                        continue;

                    try
                    {
                        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                        {
                            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                            Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{htmlPath}': {ex.Message}");
                    }

                    processedFiles.Add(htmlPath);
                }

                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}