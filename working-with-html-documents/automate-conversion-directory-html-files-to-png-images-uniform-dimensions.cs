// Automate conversion of a directory of HTML files to PNG images with uniform dimensions.

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
            // Define input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "HTMLFiles");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "PngImages");
            Directory.CreateDirectory(outputFolder);

            // Ensure the input folder exists (create a sample file if empty)
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
            }
            // Create a minimal sample HTML file if none exist
            string[] existingHtml = Directory.GetFiles(inputFolder, "*.html");
            if (existingHtml.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><body><h1>Sample</h1></body></html>");
            }

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".png");

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