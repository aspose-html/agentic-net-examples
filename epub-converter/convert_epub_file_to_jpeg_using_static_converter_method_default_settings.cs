// Convert an EPUB file to JPEG using the static Converter.ConvertEPUB method with default settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string inputPath = Path.Combine(dataDir, "sample.epub");

            if (!File.Exists(inputPath))
            {
                // Create a placeholder EPUB file (empty content)
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.jpg");

            using (FileStream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}