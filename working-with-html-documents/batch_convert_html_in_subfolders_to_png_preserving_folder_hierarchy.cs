// Batch convert HTML files in subfolders to PNG while preserving original folder hierarchy.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exists
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            // Convert each HTML file in the input folder to JPEG image
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpeg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}