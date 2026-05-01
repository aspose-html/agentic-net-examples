// Batch process a directory of EPUB files, converting each to a high‑resolution PDF for archiving.

using System;
using System.IO;
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
                string inputDir = args.Length > 0 ? args[0] : "InputEpubs";
                string outputDir = args.Length > 1 ? args[1] : "OutputPdfs";

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
                {
                    try
                    {
                        using (FileStream stream = File.OpenRead(epubPath))
                        {
                            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");
                            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                            Converter.ConvertEPUB(stream, options, outputPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to convert '{epubPath}': {ex.Message}");
                    }
                }

                Console.WriteLine("Batch conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}