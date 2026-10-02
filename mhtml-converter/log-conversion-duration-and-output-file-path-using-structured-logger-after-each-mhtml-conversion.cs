// Log conversion duration and output file path using a structured logger after each MHTML conversion.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MhtmlSamples");
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder does not exist: {folderPath}");
            return;
        }

        string[] files = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in files)
        {
            try
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    var options = new PdfSaveOptions();
                    string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                    var stopwatch = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    stopwatch.Stop();
                    Console.WriteLine($"{{\"outputPath\":\"{outputPath}\",\"durationMs\":{stopwatch.Elapsed.TotalMilliseconds}}}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert '{mhtmlPath}': {ex.Message}");
            }
        }
    }
}