// Convert an EPUB file to PDF ensuring the output directory exists before writing the file.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputDirectory = "output";
                Directory.CreateDirectory(outputDirectory);
                string outputPath = Path.Combine(outputDirectory, "result.pdf");

                using (Stream epubStream = File.OpenRead(inputPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                }

                Console.WriteLine("EPUB successfully converted to PDF: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}