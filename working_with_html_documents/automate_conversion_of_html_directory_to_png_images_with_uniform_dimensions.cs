// Automate conversion of a directory of HTML files to PNG images with uniform dimensions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPng";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure PNG image save options with uniform resolution
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;

                    // Build the output PNG file path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".png");

                    // Convert the HTML document to PNG
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}