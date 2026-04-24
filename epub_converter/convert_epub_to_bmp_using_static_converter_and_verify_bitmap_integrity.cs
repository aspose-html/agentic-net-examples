// Convert an EPUB file to BMP image using the static Converter method and verify bitmap integrity.

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
            // Path to the source EPUB file
            string epubPath = "sample.epub";
            // Path where the BMP image will be saved
            string bmpPath = "output.bmp";

            // Open the EPUB file as a readable stream
            System.IO.Stream stream = File.OpenRead(epubPath);
            // Configure image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            // Convert the EPUB to a BMP image and save to the specified path
            Converter.ConvertEPUB(stream, options, bmpPath);
            stream.Close();

            // Verify the generated bitmap by loading it and checking dimensions
            using (Bitmap bitmap = new Bitmap(bmpPath))
            {
                if (bitmap.Width > 0 && bitmap.Height > 0)
                {
                    Console.WriteLine($"Bitmap conversion successful. Dimensions: {bitmap.Width}x{bitmap.Height}");
                }
                else
                {
                    Console.WriteLine("Bitmap has invalid dimensions.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}