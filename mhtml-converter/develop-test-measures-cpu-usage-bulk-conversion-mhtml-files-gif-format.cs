// Develop a test that measures CPU usage during bulk conversion of MHTML files to GIF format.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMhtml";
            string outputFolder = "OutputGif";

            // Create folders
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create sample MHTML files
            for (int i = 1; i <= 3; i++)
            {
                string filePath = Path.Combine(inputFolder, $"sample{i}.mhtml");
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "<html><body><h1>Sample " + i + "</h1></body></html>");
                }
            }

            // Prepare for conversion
            var processedFiles = new HashSet<string>();
            string[] files = Directory.GetFiles(inputFolder, "*.mhtml");

            // Measure CPU and wall-clock time
            Process currentProcess = Process.GetCurrentProcess();
            TimeSpan cpuStart = currentProcess.TotalProcessorTime;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (string file in files)
            {
                if (processedFiles.Contains(file))
                    continue;

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(file) + ".gif");

                using (FileStream stream = File.OpenRead(file))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                processedFiles.Add(file);
            }

            sw.Stop();
            TimeSpan cpuEnd = currentProcess.TotalProcessorTime;
            TimeSpan cpuUsed = cpuEnd - cpuStart;

            Console.WriteLine($"Converted {processedFiles.Count} file(s) in {sw.Elapsed.TotalSeconds:F2} seconds (CPU time: {cpuUsed.TotalSeconds:F2} seconds).");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}