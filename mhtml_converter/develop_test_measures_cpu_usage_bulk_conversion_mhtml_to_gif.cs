// Develop a test that measures CPU usage during bulk conversion of MHTML files to GIF format.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string sourceDirectory = "MhtmlFiles";
            string outputDirectory = "GifOutputs";

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(sourceDirectory, "*.mhtml");
            if (files.Length == 0)
                return;

            Process process = Process.GetCurrentProcess();
            TimeSpan startCpu = process.TotalProcessorTime;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (string filePath in files)
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".gif");
                    Converter.ConvertMHTML(stream, options, outputPath);
                }
            }

            sw.Stop();
            TimeSpan endCpu = process.TotalProcessorTime;
            TimeSpan cpuUsed = endCpu - startCpu;

            Console.WriteLine($"Converted {files.Length} files in {sw.Elapsed.TotalSeconds:F2} seconds.");
            Console.WriteLine($"CPU time used: {cpuUsed.TotalSeconds:F2} seconds.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}