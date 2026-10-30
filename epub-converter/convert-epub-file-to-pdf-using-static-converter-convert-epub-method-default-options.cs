// Convert an EPUB file to PDF using the static Converter.ConvertEPUB method with default options.

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
            string outputPath = Path.Combine(outputDir, "result.pdf");

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file (ZIP header)
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 });
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB converted to PDF successfully. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}