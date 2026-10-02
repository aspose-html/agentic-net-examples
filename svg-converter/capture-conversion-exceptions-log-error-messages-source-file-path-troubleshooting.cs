// Capture conversion exceptions and log error messages with source file path for troubleshooting.

using System;
using System.IO;
using System.Collections.Generic;

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
            string samplePath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            HashSet<string> processedFiles = new HashSet<string>();

            foreach (string htmlPath in htmlFiles)
            {
                if (processedFiles.Contains(htmlPath))
                    continue;

                try
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpeg");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        Console.WriteLine($"Converted: {htmlPath} -> {outputPath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting file '{htmlPath}': {ex.Message}");
                }

                processedFiles.Add(htmlPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}