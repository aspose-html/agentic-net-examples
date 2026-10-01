// Convert a batch of HTML files to BMP images with custom page size using parallel processing.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputBmp");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if none exist
            string[] sampleFiles = new string[]
            {
                Path.Combine(inputFolder, "sample1.html"),
                Path.Combine(inputFolder, "sample2.html")
            };
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                File.WriteAllText(sampleFiles[0], "<html><body><h1>Sample 1</h1><p>Hello World!</p></body></html>");
                File.WriteAllText(sampleFiles[1], "<html><body><h1>Sample 2</h1><p>Another page.</p></body></html>");
            }

            // Get all HTML files
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            // Process files in parallel
            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".bmp");
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                    options.UseAntialiasing = false;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;
                    options.BackgroundColor = System.Drawing.Color.Beige;
                    options.PageSetup.AnyPage = new Page(new Size(800, 600), new Margin(0, 0, 0, 0));

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            });

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}