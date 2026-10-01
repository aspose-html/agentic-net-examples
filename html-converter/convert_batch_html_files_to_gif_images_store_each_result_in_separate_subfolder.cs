// Convert a batch of HTML files to GIF images and store each result in a separate subfolder.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputGif";

            // Ensure directories exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
            }

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Create a subfolder for this file's output
                string subFolder = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath));
                Directory.CreateDirectory(subFolder);

                // Load HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure GIF image save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                    // Define output GIF path
                    string outputPath = Path.Combine(subFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".gif");

                    // Convert HTML to GIF
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}