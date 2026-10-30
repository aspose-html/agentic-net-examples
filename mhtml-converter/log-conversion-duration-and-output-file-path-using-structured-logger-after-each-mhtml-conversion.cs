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
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlSamples");
            // Ensure the folder exists (create with a sample file if needed)
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                // Create a minimal sample MHTML file for demonstration
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "<!-- Sample MHTML content -->");
            }

            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in files)
        {
            string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            var stopwatch = Stopwatch.StartNew();
            using (FileStream inputStream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }
            stopwatch.Stop();

            // Structured log as JSON
            Console.WriteLine($"{{\"outputPath\":\"{outputPath}\",\"durationMs\":{stopwatch.ElapsedMilliseconds}}}");
        }
    }
}