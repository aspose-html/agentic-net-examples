// Convert a batch of HTML files to BMP images with custom page size using parallel processing.

using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using AsposeHtmlDrawing = Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories (use arguments if provided)
            string inputFolder = args.Length > 0 ? args[0] : @"C:\InputHtml";
            string outputFolder = args.Length > 1 ? args[1] : @"C:\OutputBmp";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files in the input folder
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            // Process files in parallel
            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                // Load HTML document
                using (var document = new HTMLDocument(htmlPath))
                {
                    // Configure image save options for BMP
                    var options = new ImageSaveOptions(ImageFormat.Bmp);
                    options.UseAntialiasing = false;
                    options.HorizontalResolution = 350;
                    options.VerticalResolution = 350;
                    options.BackgroundColor = System.Drawing.Color.Beige;

                    // Set custom page size (e.g., 800x600) with zero margins
                    options.PageSetup.AnyPage = new AsposeHtmlDrawing.Page(
                        new AsposeHtmlDrawing.Size(800, 600),
                        new AsposeHtmlDrawing.Margin(0, 0, 0, 0));

                    // Determine output BMP path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".bmp");

                    // Convert HTML to BMP
                    Converter.ConvertHTML(document, options, outputPath);
                }
            });

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}