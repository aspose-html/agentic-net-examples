// Convert an EPUB file to PDF specifying the output path using Path.Combine for platform‑independent paths.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = System.IO.Path.Combine("Data", "sample.epub");
            string outputPath = System.IO.Path.Combine("Output", "sample.pdf");

            // Ensure output directory exists
            string outputDir = System.IO.Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}