// Implement logging of input EPUB metadata before conversion to assist in troubleshooting output GIF issues.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Log EPUB metadata
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(inputPath);
            Console.WriteLine($"EPUB Path: {fileInfo.FullName}");
            Console.WriteLine($"Size (bytes): {fileInfo.Length}");
            Console.WriteLine($"Created: {fileInfo.CreationTime}");

            // Convert EPUB to GIF
            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine($"Conversion completed. GIF saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}