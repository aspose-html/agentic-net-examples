// Perform parallel conversion of multiple HTML files to PNG using Parallel.ForEach to improve processing speed.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputPng");

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><body><h1>Sample</h1></body></html>");
            }

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".png");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine($"Converted: {Path.GetFileName(htmlPath)} -> {Path.GetFileName(outputPath)}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}