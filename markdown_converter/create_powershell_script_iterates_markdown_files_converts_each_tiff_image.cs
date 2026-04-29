// Create a PowerShell script that iterates over Markdown files and converts each to a TIFF image.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MarkdownToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input directory containing markdown files (default current directory)
                string inputDir = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

                // Output directory for generated TIFF images
                string outputDir = args.Length > 1 ? args[1] : Path.Combine(inputDir, "tiff_output");
                Directory.CreateDirectory(outputDir);

                // Iterate over all markdown files in the input directory
                foreach (string sourcePath in Directory.GetFiles(inputDir, "*.md"))
                {
                    // Determine output TIFF file path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                    string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                    // Convert markdown file to an Aspose.Html HTMLDocument
                    HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                    // Configure image save options for TIFF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                    // Render the HTMLDocument to a TIFF image file
                    Converter.ConvertHTML(document, options, savePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}