// Convert HTML to JPEG using an environment variable to define the output directory for flexibility.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlToJpegExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string inputPath = "input.html";

                // Retrieve output directory from environment variable; fallback to "output"
                string outputDir = Environment.GetEnvironmentVariable("OUTPUT_DIR") ?? "output";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDir);

                // Build the full output JPEG file path
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                // Configure image save options for JPEG format
                Aspose.Html.Saving.ImageSaveOptions options =
                    new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}