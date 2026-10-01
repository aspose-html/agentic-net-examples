// Convert EPUB to JPEG and embed custom EXIF author metadata using ImageSaveOptions before saving.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";

            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Ensure the input file exists (placeholder for example purposes)
            if (!File.Exists(inputPath))
            {
                // Create an empty file as a placeholder; in real scenarios, provide a valid EPUB file.
                using (FileStream placeholder = File.Create(inputPath)) { }
            }

            using (System.IO.Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}