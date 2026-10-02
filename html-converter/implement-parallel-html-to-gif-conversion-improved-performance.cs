// Implement parallel HTML to GIF conversion using Parallel.ForEach and Converter.ConvertHTML for improved performance.

using System;
using System.IO;
using System.Threading.Tasks;
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
            string inputFolder = "InputHtml";
            string outputFolder = "OutputGif";

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
            }

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                try
                {
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".gif");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting '{htmlPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}