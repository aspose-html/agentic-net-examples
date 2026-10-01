// Implement error handling for missing Markdown files during batch conversion to JPEG images.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "MarkdownFiles";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            string samplePath = Path.Combine(inputFolder, "sample.md");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "# Sample Markdown\nThis is a sample markdown file.");
            }

            string[] markdownFiles = Directory.GetFiles(inputFolder, "*.md");
            if (markdownFiles.Length == 0)
            {
                Console.WriteLine("No markdown files found in the input folder.");
                return;
            }

            foreach (string mdPath in markdownFiles)
            {
                try
                {
                    if (!File.Exists(mdPath))
                    {
                        Console.WriteLine($"File not found: {mdPath}");
                        continue;
                    }

                    using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.UseAntialiasing = true;
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;

                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        Console.WriteLine($"Converted '{mdPath}' to '{outputPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file '{mdPath}': {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}