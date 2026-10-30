// Batch process a set of Markdown files, converting each to TIFF with lossless compression enabled.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create sample markdown files if none exist
            string[] sampleFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.md"),
                Path.Combine(inputDir, "sample2.md")
            };

            if (!File.Exists(sampleFiles[0]))
                File.WriteAllText(sampleFiles[0], "# Sample 1\r\nThis is a test markdown file.");

            if (!File.Exists(sampleFiles[1]))
                File.WriteAllText(sampleFiles[1], "# Sample 2\r\nAnother test markdown file.");

            string[] markdownFiles = Directory.GetFiles(inputDir, "*.md");

            foreach (string sourcePath in markdownFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.Compression = Aspose.Html.Rendering.Image.Compression.None; // use default compression

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