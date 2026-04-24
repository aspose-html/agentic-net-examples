// Perform parallel conversion of multiple HTML files to PNG using Parallel.ForEach to improve processing speed.

using System;
using System.IO;
using System.Threading.Tasks;
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
            // Folder containing HTML files
            string inputFolder = @"C:\InputHtml";
            // Folder where PNG images will be saved
            string outputFolder = @"C:\OutputPng";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files in the input folder
            var htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            // Convert each HTML file to PNG in parallel
            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                // Create HTML document from file
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Configure PNG output options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                // Build output PNG file path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(htmlPath) + ".png");

                // Perform conversion
                Converter.ConvertHTML(document, options, outputPath);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}