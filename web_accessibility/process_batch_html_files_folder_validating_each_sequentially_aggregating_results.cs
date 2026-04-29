// Process a batch of HTML files in a folder, validating each file sequentially and aggregating results.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace BatchHtmlToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output directories
                string inputFolder = @"C:\InputHtml";
                string outputFolder = @"C:\OutputJpeg";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputFolder);

                int totalFiles = 0;
                int successCount = 0;
                int failureCount = 0;

                // Process each HTML file in the input folder
                foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
                {
                    totalFiles++;
                    try
                    {
                        // Load the HTML document
                        using (HTMLDocument document = new HTMLDocument(htmlPath))
                        {
                            // Configure JPEG conversion options
                            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                            // Determine output file path
                            string outputPath = Path.Combine(
                                outputFolder,
                                Path.GetFileNameWithoutExtension(htmlPath) + ".jpeg");

                            // Convert HTML to JPEG
                            Converter.ConvertHTML(document, options, outputPath);
                        }

                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        // Log conversion errors for this file
                        Console.WriteLine($"Error processing '{htmlPath}': {ex.Message}");
                        failureCount++;
                    }
                }

                // Output aggregation results
                Console.WriteLine($"Processed {totalFiles} file(s). Success: {successCount}, Failed: {failureCount}");
            }
            catch (Exception e)
            {
                // Log any unexpected errors
                Console.WriteLine($"Fatal error: {e.Message}");
            }
        }
    }
}