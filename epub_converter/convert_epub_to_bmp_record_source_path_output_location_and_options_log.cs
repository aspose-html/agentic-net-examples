// Convert EPUB to BMP while recording source file path, output location, and options used into a log.

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
            // Path to the source EPUB file
            string sourcePath = "sample.epub";

            // Desired output BMP file path
            string outputPath = "sample.bmp";

            // Open the EPUB file as a stream (rule: System.IO.Stream {stream} = File.OpenRead({string_literal});)
            System.IO.Stream stream = File.OpenRead(sourcePath);

            // Configure image save options for BMP format (rule: Aspose.Html.Saving.ImageSaveOptions {options} = new Aspose.Html.Saving.ImageSaveOptions(ImageFormat.Bmp);)
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Convert the EPUB to BMP (rule: Aspose.Html.Converters.Converter.ConvertEPUB({stream}, {options}, {outputPath});)
            Converter.ConvertEPUB(stream, options, outputPath);

            // Log conversion details
            string logContent = $"Source: {sourcePath}{Environment.NewLine}Output: {outputPath}{Environment.NewLine}Options: BMP format";
            File.WriteAllText("conversion.log", logContent);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}