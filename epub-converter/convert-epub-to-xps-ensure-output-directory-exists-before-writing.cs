// Convert an EPUB file to XPS ensuring the output directory exists before writing the file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "result.xps");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Create a minimal placeholder EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Placeholder EPUB content");
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}