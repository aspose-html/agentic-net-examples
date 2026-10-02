// Batch process a set of Markdown files, converting each to TIFF with lossless compression enabled.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputMarkdown";
            string outputDir = "OutputTiff";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputDir, "*.md").Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.md");
                string sampleContent = "# Sample Markdown\r\n\r\nThis is a **test** markdown file.";
                File.WriteAllText(samplePath, sampleContent);
            }

            foreach (string sourcePath in Directory.GetFiles(inputDir, "*.md"))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                }

                Console.WriteLine($"Converted '{sourcePath}' to '{savePath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}