// Convert EPUB to BMP with ImageSaveOptions.BackgroundColor set to light gray to improve visual contrast.

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
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                options.BackgroundColor = Color.LightGray;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine("EPUB has been successfully converted to BMP.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}