// Automate conversion of a directory of HTML files to PNG images with uniform dimensions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input_html");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output_png");

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // If no HTML files are present, create a minimal sample file
            string[] existingHtmlFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingHtmlFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure image save options for PNG with uniform resolution
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Determine output PNG path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".png");

                    // Convert HTML to PNG
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