// Benchmark conversion time for MHTML to GIF using different ImageSaveOptions quality levels.

using System;
using System.Diagnostics;
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
            string inputPath = "sample.mhtml";
            string[] outputPaths = { "output_low.gif", "output_medium.gif", "output_high.gif" };

            for (int i = 0; i < outputPaths.Length; i++)
            {
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    Stopwatch sw = Stopwatch.StartNew();
                    Converter.ConvertMHTML(stream, options, outputPaths[i]);
                    sw.Stop();
                    Console.WriteLine($"Conversion {i + 1} completed in {sw.ElapsedMilliseconds} ms, output: {outputPaths[i]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}