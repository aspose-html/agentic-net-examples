// Write a helper that converts MHTML to multiple image formats in a single pass using parallel tasks.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputDir = "output";

            // Ensure input file exists (create a minimal placeholder if needed)
            if (!File.Exists(inputPath))
            {
                string placeholder = "From: test@example.com\r\nSubject: Test\r\n\r\n<html><body><h1>Hello</h1></body></html>";
                File.WriteAllText(inputPath, placeholder);
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var formats = new (Aspose.Html.Rendering.Image.ImageFormat format, string extension)[]
            {
                (Aspose.Html.Rendering.Image.ImageFormat.Jpeg, "jpg"),
                (Aspose.Html.Rendering.Image.ImageFormat.Png, "png"),
                (Aspose.Html.Rendering.Image.ImageFormat.Tiff, "tiff"),
                (Aspose.Html.Rendering.Image.ImageFormat.Bmp, "bmp")
            };

            Task[] tasks = new Task[formats.Length];
            for (int i = 0; i < formats.Length; i++)
            {
                var fmt = formats[i];
                tasks[i] = Task.Run(() =>
                {
                    using (Stream stream = File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(fmt.format);
                        // Optional properties
                        options.UseAntialiasing = true;
                        options.HorizontalResolution = 96;
                        options.VerticalResolution = 96;

                        string outputPath = Path.Combine(outputDir, $"output.{fmt.extension}");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        Console.WriteLine($"Converted to {outputPath}");
                    }
                });
            }

            Task.WaitAll(tasks);
            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}