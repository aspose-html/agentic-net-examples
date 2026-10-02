// Convert a batch of HTML files to TIFF images while applying different compression levels per file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input_html");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output_tiff");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create sample HTML files
            string htmlPath1 = Path.Combine(inputFolder, "sample1.html");
            string htmlPath2 = Path.Combine(inputFolder, "sample2.html");
            File.WriteAllText(htmlPath1, "<html><body><h1>Sample 1</h1></body></html>");
            File.WriteAllText(htmlPath2, "<html><body><h1>Sample 2</h1></body></html>");

            // Get all HTML files in the input folder
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                string htmlPath = htmlFiles[i];
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    // Apply different compression per file
                    if (i % 2 == 0)
                    {
                        // For even-indexed files use no compression
                        options.Compression = Compression.None;
                    }
                    // else leave default compression (could be LZW or other default)

                    // Optional: set resolution
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".tiff");

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}