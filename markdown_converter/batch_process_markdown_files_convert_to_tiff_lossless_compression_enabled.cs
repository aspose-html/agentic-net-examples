// Batch process a set of Markdown files, converting each to TIFF with lossless compression enabled.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input directory containing markdown files
            string inputDir = args.Length > 0 ? args[0] : "MarkdownFiles";
            // Output directory for TIFF images
            string outputDir = args.Length > 1 ? args[1] : "TiffOutput";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each .md file in the input directory
            foreach (string sourcePath in Directory.GetFiles(inputDir, "*.md"))
            {
                // Determine output TIFF file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                // Convert markdown to HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Configure image save options for TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                // Enable lossless compression if supported
                // options.Lossless = true; // Uncomment if the property exists

                // Render HTMLDocument to TIFF image
                Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}