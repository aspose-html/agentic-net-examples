// Extract a TIFF thumbnail of the opening page from an EPUB using Converter.ConvertEPUB with page range set to zero.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "thumbnail.tiff";

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file if it does not exist
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 96,
                    VerticalResolution = 96,
                    BackgroundColor = System.Drawing.Color.White
                };

                // Define a small page size for the thumbnail (e.g., 200x200 pixels)
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(200, 200),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Thumbnail saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}