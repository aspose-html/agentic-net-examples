// Batch convert HTML files to images, specifying DPI and output format for each conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace BatchHtmlToImage
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare output directory
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output_images");
                Directory.CreateDirectory(outputDir);

                // Input HTML files
                string[] inputs = new string[]
                {
                    "sample1.html",
                    "sample2.html"
                };

                // DPI settings
                int dpiX = 150;
                int dpiY = 150;

                for (int i = 0; i < inputs.Length; i++)
                {
                    string inputPath = inputs[i];

                    // Load HTML document
                    using (HTMLDocument document = new HTMLDocument(inputPath, Directory.GetCurrentDirectory()))
                    {
                        // Configure image save options (JPEG format)
                        var options = new ImageSaveOptions(ImageFormat.Jpeg);
                        options.HorizontalResolution = dpiX;
                        options.VerticalResolution = dpiY;

                        // Build output file path
                        string outputPath = Path.Combine(outputDir,
                            Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                        // Convert HTML to image
                        Converter.ConvertHTML(document, options, outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}