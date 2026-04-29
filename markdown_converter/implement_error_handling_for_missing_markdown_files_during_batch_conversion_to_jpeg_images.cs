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
            // Define input folder containing markdown files and output folder for JPEG images
            string inputFolder = "MarkdownFiles";
            string outputFolder = "OutputImages";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Iterate over all markdown files in the input folder
            foreach (string markdownPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                try
                {
                    // Verify that the markdown file exists
                    if (!File.Exists(markdownPath))
                        throw new FileNotFoundException($"Markdown file not found: {markdownPath}");

                    // Determine the output JPEG file path
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(markdownPath) + ".jpg");

                    // Convert the markdown file to an HTMLDocument
                    Aspose.Html.HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

                    // Configure image save options for JPEG format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    // Render the HTMLDocument to a JPEG image
                    Converter.ConvertHTML(document, options, outputPath);
                }
                catch (Exception ex)
                {
                    // Handle errors for individual files (e.g., missing file, conversion failure)
                    Console.WriteLine($"Error processing file '{markdownPath}': {ex.Message}");
                }
            }
        }
        catch (Exception e)
        {
            // Handle any unexpected errors that may occur during setup or iteration
            Console.WriteLine($"Fatal error: {e.Message}");
        }
    }
}