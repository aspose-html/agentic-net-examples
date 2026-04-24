// Convert EPUB to BMP with ImageSaveOptions.BackgroundColor set to light gray to improve visual contrast.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.bmp";

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                options.BackgroundColor = Color.LightGray;
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}