// Create a PowerShell script that iterates over Markdown files and converts each to a TIFF image.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MarkdownToTiffExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDir = "MarkdownFiles";
                string outputDir = "OutputImages";

                Directory.CreateDirectory(inputDir);
                Directory.CreateDirectory(outputDir);

                // Create a sample markdown file if none exist
                string[] mdFiles = Directory.GetFiles(inputDir, "*.md");
                if (mdFiles.Length == 0)
                {
                    string samplePath = Path.Combine(inputDir, "sample.md");
                    File.WriteAllText(samplePath, "# Sample Markdown\r\nThis is a test.");
                    mdFiles = new[] { samplePath };
                }

                foreach (string sourcePath in mdFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sourcePath);
                    string savePath = Path.Combine(outputDir, fileName + ".tiff");

                    HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

                    Console.WriteLine($"Converted '{sourcePath}' to '{savePath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}