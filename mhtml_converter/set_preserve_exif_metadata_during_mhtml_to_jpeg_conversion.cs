// Set ImageSaveOptions to preserve EXIF metadata when converting MHTML to JPEG images.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mhtml";
            string outputPath = "output.jpg";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                // Preserve EXIF metadata is not supported in this version of Aspose.HTML.
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}