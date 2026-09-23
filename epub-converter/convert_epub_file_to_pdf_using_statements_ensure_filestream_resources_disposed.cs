// Convert an EPUB file to PDF using using statements to ensure FileStream resources are disposed.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                using (FileStream fs = File.Create(inputPath))
                {
                    // Placeholder EPUB file (empty)
                }
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB converted to PDF successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}