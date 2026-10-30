// Implement error handling for missing Markdown files during batch conversion to JPEG images.

using System;
using System.IO;
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
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputFolder, "*.md").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                string sampleContent = "# Sample Markdown\n\nThis is a *test* markdown file.";
                File.WriteAllText(samplePath, sampleContent);
            }

            foreach (string markdownPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                try
                {
                    if (!File.Exists(markdownPath))
                    {
                        Console.WriteLine($"File not found: {markdownPath}");
                        continue;
                    }

                    using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                        string outputPath = Path.Combine(outputFolder,
                            Path.GetFileNameWithoutExtension(markdownPath) + ".jpg");

                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        Console.WriteLine($"Converted '{markdownPath}' to '{outputPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{markdownPath}': {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}