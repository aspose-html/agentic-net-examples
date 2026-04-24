// Convert a batch of HTML files located in a directory to PNG images using a foreach loop.

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
            string inputFolder = @"C:\HtmlInput";
            string outputFolder = @"C:\PngOutput";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Set up PNG image save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                    // Determine the output PNG file path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".png");

                    // Convert the HTML document to PNG
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}