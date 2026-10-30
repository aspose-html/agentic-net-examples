// Convert EPUB to TIFF and archive all output files into a ZIP container to simplify file management.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output directories
            string inputPath = "sample.epub";
            string outputDir = "output";
            string zipPath = "output.zip";

            // Ensure output directory exists
            System.IO.Directory.CreateDirectory(outputDir);

            // Open EPUB file stream
            using (System.IO.Stream epubStream = System.IO.File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    Compression = Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = System.Drawing.Color.White
                };
                options.PageSetup.AnyPage = new Page(new Size(800, 1000), new Margin(0, 0, 0, 0));

                // Convert EPUB pages to TIFF images saved in outputDir
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputDir);
            }

            // Create ZIP archive containing all generated TIFF files
            if (System.IO.File.Exists(zipPath))
            {
                System.IO.File.Delete(zipPath);
            }
            System.IO.Compression.ZipFile.CreateFromDirectory(outputDir, zipPath);

            Console.WriteLine("EPUB conversion to TIFF completed and archived to: " + zipPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}