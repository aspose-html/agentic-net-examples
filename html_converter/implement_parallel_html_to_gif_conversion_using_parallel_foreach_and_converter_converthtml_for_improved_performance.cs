// Implement parallel HTML to GIF conversion using Parallel.ForEach and Converter.ConvertHTML for improved performance.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace ParallelHtmlToGif
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input folder containing HTML files and output folder for GIFs
                string inputFolder = "InputHtml";
                string outputFolder = "OutputGif";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputFolder);

                // Get all HTML files in the input folder
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

                // Convert each HTML file to GIF in parallel
                Parallel.ForEach(htmlFiles, htmlPath =>
                {
                    // Load the HTML document
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        // Set image save options to GIF format
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                        // Determine the output GIF path
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".gif");

                        // Perform the conversion
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                });

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}