// Develop a test that measures CPU usage during bulk conversion of MHTML files to GIF format.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMhtml";
            string outputFolder = "OutputGif";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample MHTML file (for demonstration purposes)
            string sampleMhtmlPath = Path.Combine(inputFolder, "sample1.mht");
            File.WriteAllText(sampleMhtmlPath, "<html><body><h1>Sample</h1></body></html>");

            string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mht");
            // Include .mhtml extension as well
            string[] additionalFiles = Directory.GetFiles(inputFolder, "*.mhtml");
            string[] allFiles = new string[mhtmlFiles.Length + additionalFiles.Length];
            mhtmlFiles.CopyTo(allFiles, 0);
            additionalFiles.CopyTo(allFiles, mhtmlFiles.Length);

            Process currentProcess = Process.GetCurrentProcess();
            TimeSpan cpuStart = currentProcess.TotalProcessorTime;

            foreach (string filePath in allFiles)
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".gif");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
            }

            TimeSpan cpuEnd = currentProcess.TotalProcessorTime;
            TimeSpan cpuUsed = cpuEnd - cpuStart;

            Console.WriteLine($"CPU time used for conversion: {cpuUsed.TotalMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}