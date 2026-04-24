// Convert all EPUB files in a directory to PDF using Parallel.ForEach with default PdfSaveOptions.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace EpubToPdfBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDir = args.Length > 0 ? args[0] : "input";
                string outputDir = args.Length > 1 ? args[1] : "output";

                if (!Directory.Exists(inputDir))
                {
                    Console.WriteLine($"Input directory does not exist: {inputDir}");
                    return;
                }

                Directory.CreateDirectory(outputDir);

                var epubFiles = Directory.GetFiles(inputDir, "*.epub", SearchOption.TopDirectoryOnly);

                Parallel.ForEach(epubFiles, epubPath =>
                {
                    try
                    {
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");
                        using (var stream = File.OpenRead(epubPath))
                        {
                            var options = new PdfSaveOptions();
                            Converter.ConvertEPUB(stream, options, outputPath);
                        }
                        Console.WriteLine($"Converted: {epubPath} -> {outputPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to convert {epubPath}: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}