// Batch process EPUB chapters, converting each chapter to a separate PDF file for distribution.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace BatchEpubToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDir = "InputEpubs";
                string outputDir = "OutputPdfs";

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
                {
                    using (FileStream stream = new FileStream(epubPath, FileMode.Open, FileAccess.Read))
                    {
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");
                        PdfSaveOptions options = new PdfSaveOptions();
                        Converter.ConvertEPUB(stream, options, outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}