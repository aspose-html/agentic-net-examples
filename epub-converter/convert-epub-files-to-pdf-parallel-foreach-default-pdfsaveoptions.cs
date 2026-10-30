// Convert all EPUB files in a directory to PDF using Parallel.ForEach with default PdfSaveOptions.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "epubs";
            string outputDir = "pdfs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");

            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    using (Stream stream = File.OpenRead(epubPath))
                    {
                        var options = new Aspose.Html.Saving.PdfSaveOptions();
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                        Console.WriteLine($"Converted: {epubPath} -> {outputPath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting {epubPath}: {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}