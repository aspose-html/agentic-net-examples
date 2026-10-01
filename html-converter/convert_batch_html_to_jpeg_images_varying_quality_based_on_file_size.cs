// Convert a batch of HTML files to JPEG images with varying quality settings based on file size.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "HtmlFiles");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "JpegOutput");
            Directory.CreateDirectory(outputFolder);

            // Ensure there is at least one sample HTML file
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                Directory.CreateDirectory(inputFolder);
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Sample HTML</h1></body></html>");
            }

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Determine resolution based on file size
                long fileSize = new FileInfo(htmlPath).Length;
                int horizontalResolution;
                int verticalResolution;

                if (fileSize > 50000) // larger than 50 KB
                {
                    horizontalResolution = 72;
                    verticalResolution = 72;
                }
                else if (fileSize > 20000) // between 20 KB and 50 KB
                {
                    horizontalResolution = 150;
                    verticalResolution = 150;
                }
                else // small files
                {
                    horizontalResolution = 300;
                    verticalResolution = 300;
                }

                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.HorizontalResolution = horizontalResolution;
                    options.VerticalResolution = verticalResolution;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}