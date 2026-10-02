// Batch process EPUB chapters, converting each chapter to a separate PDF file for distribution.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputPdfs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a minimal sample EPUB if none exist (placeholder)
            string sampleEpubPath = Path.Combine(inputDir, "sample.epub");
            if (!File.Exists(sampleEpubPath))
            {
                File.WriteAllBytes(sampleEpubPath, new byte[0]);
            }

            foreach (string epubFile in Directory.GetFiles(inputDir, "*.epub"))
            {
                using (FileStream stream = new FileStream(epubFile, FileMode.Open, FileAccess.Read))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubFile) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}