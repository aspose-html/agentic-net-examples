// Convert EPUB to BMP with ImageSaveOptions.BackgroundColor set to light gray to improve visual contrast.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                // Create an empty placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.BackgroundColor = Color.LightGray;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to BMP.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}