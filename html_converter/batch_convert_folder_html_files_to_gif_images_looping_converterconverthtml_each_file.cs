// Batch convert a folder of HTML files to GIF images by looping Converter.ConvertHTML for each file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputGif";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure image save options for GIF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                    // Build the output GIF file path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".gif");

                    // Convert the HTML document to a GIF image
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}