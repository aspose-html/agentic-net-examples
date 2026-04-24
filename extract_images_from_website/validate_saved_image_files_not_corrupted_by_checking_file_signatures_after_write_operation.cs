// Validate that saved image files are not corrupted by checking file signatures after write operation.

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
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "result.jpg");

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            byte[] bytes = File.ReadAllBytes(outputPath);
            bool isValid = bytes.Length > 3 &&
                bytes[0] == 0xFF && bytes[1] == 0xD8 &&
                bytes[bytes.Length - 2] == 0xFF && bytes[bytes.Length - 1] == 0xD9;

            Console.WriteLine(isValid ? "Image file is valid." : "Image file is corrupted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}