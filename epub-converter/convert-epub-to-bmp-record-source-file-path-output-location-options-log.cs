// Convert EPUB to BMP while recording source file path, output location, and options used into a log.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define source EPUB file path and output BMP file path
            string sourcePath = "sample.epub";
            string outputPath = "output.bmp";

            // Ensure the source file exists (create a placeholder if missing)
            if (!File.Exists(sourcePath))
            {
                // Create an empty placeholder EPUB file
                File.WriteAllBytes(sourcePath, new byte[0]);
                Console.WriteLine("Created placeholder EPUB file at: " + Path.GetFullPath(sourcePath));
            }

            // Log the conversion parameters
            Console.WriteLine("Converting EPUB to BMP");
            Console.WriteLine("Source file: " + Path.GetFullPath(sourcePath));
            Console.WriteLine("Output file: " + Path.GetFullPath(outputPath));
            Console.WriteLine("Image format: BMP");

            // Prepare the input stream
            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Configure image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}