// Log conversion duration and output file path using a structured logger after each MHTML conversion.

using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlSamples");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                string samplePath = Path.Combine(folder, "sample.mhtml");
                File.WriteAllText(samplePath, "");
            }

            ConvertMhtmlFilesInFolder(folder);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in files)
        {
            try
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");

                    Stopwatch sw = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    sw.Stop();

                    Console.WriteLine($"{{\"outputPath\":\"{outputPath}\",\"durationMs\":{sw.ElapsedMilliseconds}}}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to convert '{mhtmlPath}': {ex.Message}");
            }
        }
    }
}