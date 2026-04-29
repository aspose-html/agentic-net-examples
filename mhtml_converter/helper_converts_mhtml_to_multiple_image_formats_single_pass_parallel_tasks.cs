// Write a helper that converts MHTML to multiple image formats in a single pass using parallel tasks.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string mhtmlPath = "input.mhtml";
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            ConvertMhtmlToImages(mhtmlPath, outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToImages(string mhtmlPath, string outputDir)
    {
        // Load the MHTML file into memory once
        byte[] mhtmlData = File.ReadAllBytes(mhtmlPath);

        // Define target image formats and file extensions
        var targets = new (ImageFormat format, string extension)[]
        {
            (ImageFormat.Jpeg, "jpg"),
            (ImageFormat.Png, "png"),
            (ImageFormat.Tiff, "tiff"),
            (ImageFormat.Bmp, "bmp")
        };

        // Create a task for each conversion
        Task[] tasks = new Task[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            var target = targets[i];
            tasks[i] = Task.Run(() =>
            {
                // Provide a fresh stream for each conversion
                using (var stream = new MemoryStream(mhtmlData))
                {
                    // Configure image save options for the specific format
                    ImageSaveOptions options = new ImageSaveOptions(target.format);
                    string outputPath = Path.Combine(outputDir, $"output.{target.extension}");

                    // Perform the conversion
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
            });
        }

        // Wait for all conversions to finish
        Task.WaitAll(tasks);
    }
}