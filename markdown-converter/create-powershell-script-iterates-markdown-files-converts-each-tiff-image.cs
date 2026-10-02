// Create a PowerShell script that iterates over Markdown files and converts each to a TIFF image.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "MarkdownFiles");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "TiffOutput");

            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a sample markdown file if none exist
            string[] existingFiles = Directory.GetFiles(inputDir, "*.md");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\r\nThis is a *test*.");
                existingFiles = new[] { samplePath };
            }

            foreach (string sourcePath in existingFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                }

                Console.WriteLine($"Converted '{sourcePath}' to TIFF at '{savePath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}