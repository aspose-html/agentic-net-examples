// Parallel convert a collection of EPUB documents to BMP images with concurrent tasks to reduce overall runtime.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample EPUB file paths
            string[] epubFiles = new string[]
            {
                "sample1.epub",
                "sample2.epub"
            };

            // Ensure sample files exist (empty placeholder files)
            foreach (string path in epubFiles)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, new byte[0]);
                }
            }

            // Parallel conversion of each EPUB to BMP images
            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    using (Stream stream = File.OpenRead(epubPath))
                    {
                        // Configure BMP image save options
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                        // Output directory for BMP images
                        string outputDir = Path.Combine(
                            Path.GetDirectoryName(epubPath) ?? "",
                            Path.GetFileNameWithoutExtension(epubPath) + "_bmp");

                        Directory.CreateDirectory(outputDir);

                        // Convert EPUB to BMP images
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputDir);
                    }

                    Console.WriteLine($"Successfully converted '{epubPath}' to BMP images.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}