// Convert EPUB to BMP using ImageSaveOptions to specify 200 DPI, producing sharper bitmap images.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace EpubToBmpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string epubPath = "input.epub";
                string bmpPath = "output.bmp";

                using (Stream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                    options.HorizontalResolution = 200;
                    options.VerticalResolution = 200;

                    Converter.ConvertEPUB(stream, options, bmpPath);
                }

                Console.WriteLine("EPUB successfully converted to BMP.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}