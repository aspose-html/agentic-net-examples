// Parallelize conversion of multiple EPUB files to JPEG using Parallel.ForEach to improve processing throughput.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB files (replace with actual paths or add more files)
            string[] epubFiles = new string[]
            {
                "Sample1.epub",
                "Sample2.epub",
                "Sample3.epub"
            };

            // Define output directory
            string outputDir = "OutputImages";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Parallel conversion
            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    if (!File.Exists(epubPath))
                    {
                        Console.WriteLine($"Input file not found: {epubPath}");
                        return;
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".jpg";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    using (FileStream inputStream = File.OpenRead(epubPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(
                            Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                        Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
                    }

                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}