// Batch render a set of MHTML newsletters to PNG images for email preview generation.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input MHTML files
            string[] mhtmlFiles = new string[]
            {
                "newsletter1.mhtml",
                "newsletter2.mhtml"
            };

            // Ensure sample MHTML files exist
            foreach (string filePath in mhtmlFiles)
            {
                if (!File.Exists(filePath))
                {
                    string sampleHtml = "<html><body><h1>Sample Newsletter</h1><p>This is a sample newsletter content.</p></body></html>";
                    File.WriteAllText(filePath, sampleHtml);
                }
            }

            // Process each MHTML file
            foreach (string inputPath in mhtmlFiles)
            {
                // Define output PNG path
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Open MHTML file stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Configure image save options for PNG
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    options.UseAntialiasing = true;

                    // Convert MHTML to PNG
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}