// Convert an EPUB file to JPEG using the static Converter.ConvertEPUB method with default settings.

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
            string epubPath = "input.epub";
            string outputPath = "output.jpg";

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}