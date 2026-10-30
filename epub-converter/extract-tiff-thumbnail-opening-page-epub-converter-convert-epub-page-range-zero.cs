// Extract a TIFF thumbnail of the opening page from an EPUB using Converter.ConvertEPUB with page range set to zero.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output TIFF thumbnail path
            string outputPath = "thumbnail.tiff";

            // Open EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    Compression = Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = Color.White
                };

                // Convert the opening page of the EPUB to a TIFF thumbnail
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Thumbnail saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}