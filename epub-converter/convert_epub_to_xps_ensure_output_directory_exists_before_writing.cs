// Convert an EPUB file to XPS ensuring the output directory exists before writing the file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "output.xps");

            Directory.CreateDirectory(outputDir);

            if (!File.Exists(sourcePath))
            {
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(sourcePath))
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}